using System;
using Level.Blocks;
using Zenject;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class Level : IInitializable, ITickable
    {
        public event Action OnLevelOver; 

        private readonly Vector2Int[] _swapDirections = 
            {new Vector2Int(1, 0), new Vector2Int (-1, 0), new Vector2Int (0, 1), new Vector2Int (0, -1)};
        
        private readonly IBlockPool _blockPool;
        private readonly List<Transform> _squareSpawnersList;
        private readonly CentralBaseBlockView _centralBlock;
        private BaseBlockView _currentPlayerBlock;
        private float _creationFrequency;
        private float _frequencySecond = 3f;
        private int _countBlocksLevel = 3;
        private int _tempCountBlocksLevel;
        private int _countSwappedBlocks;
        private bool _isLevelStart;

        public int CountSwappedBlocks
        {
            get => _countSwappedBlocks;
            set
            {
                _countSwappedBlocks = value;
                if (_countSwappedBlocks == _countBlocksLevel)
                {
                    OnLevelOver?.Invoke();
                }
            }
        }
        
        public int CountBlocksLevel
        {
            get => _tempCountBlocksLevel;
            private set
            {
                _tempCountBlocksLevel = value;
                _creationFrequency = Mathf.Max(_tempCountBlocksLevel / _frequencySecond, 2f);
            }
        }

        [Inject]
        public Level(IBlockPool pool, List<Transform> squareSpawners, 
            CentralBaseBlockView centralBlock)
        {
            _blockPool = pool;
            _centralBlock = centralBlock; 
            _squareSpawnersList = squareSpawners;
        }
        
        public void Initialize()
        {
            CountBlocksLevel = _countBlocksLevel;
            _centralBlock.OnPlayersSquareTouch += OnLeveOver;
        }
        
        public void Tick()
        {
            if (!_isLevelStart) return;
            
            if (_creationFrequency <= 0 && CountBlocksLevel > 0)
            {
                CreateSquareWithRandomDirections();
                CountBlocksLevel--;
            }
            else
            {
                _creationFrequency -= Time.deltaTime;
            }
        }

        private void CreateSquareWithRandomDirections()
        {
            _currentPlayerBlock = _blockPool.Get();
            var randomSpawnerTransform = _squareSpawnersList[Random.Range(0, _squareSpawnersList.Count)];
            
            _currentPlayerBlock.gameObject.transform.position = randomSpawnerTransform.position; 
            _currentPlayerBlock.gameObject.SetActive(true);
            
            SetSquareDirections(randomSpawnerTransform);
            _currentPlayerBlock.MoveTo(_centralBlock.gameObject.transform.position, 3);
        }

        private void SetSquareDirections(Transform randomTransform)
        {
            var movementDirection = GetMovementDirection(randomTransform);
            SetSquareSwapDirection(movementDirection);
            _currentPlayerBlock.gameObject.transform.rotation = Quaternion.Euler(GetRotationAnglesFrom(movementDirection));
        }

        private Vector2 GetMovementDirection(Transform spawnerTransform)
        {
            var direction = _centralBlock.gameObject.transform.position - spawnerTransform.position;
            direction.Normalize();
            return direction;
        }

        private Vector3 GetRotationAnglesFrom(Vector2 movementDirection)
        {
            var swapDirection = _currentPlayerBlock.SwapDirection;
            var angleRotation = Vector3.zero;
            
            switch (swapDirection)
            {
                case var right when right.Equals(Vector2Int.right):
                    angleRotation = Vector3.forward * 270; 
                    break;
                case var down when down.Equals(Vector2Int.down):
                    angleRotation = Vector3.forward * 180;
                    break;
                case var left when left.Equals(Vector2Int.left):
                    angleRotation = Vector3.forward * 90;
                    break;
                case var up when up.Equals(Vector2Int.up):
                    angleRotation = Vector3.forward * 0;
                    break;
            }
            
            return angleRotation;
        }

        private void SetSquareSwapDirection(Vector2 movementDirection)
        {
            var swapDirection = _swapDirections[Random.Range(0, _swapDirections.Length)];
            while (swapDirection == Vector2Int.RoundToInt(movementDirection))
            {
                swapDirection = _swapDirections[Random.Range(0, _swapDirections.Length)];
            }

            _currentPlayerBlock.SwapDirection = swapDirection;
        }

        public void LevelStart()
        {
            CountBlocksLevel = _countBlocksLevel;
            CountSwappedBlocks = 0;
            _blockPool.DeactivationAllObject();
            _isLevelStart = true;
        }

        public void OnLeveOver()
        {
            _isLevelStart = false;
        }
    }
}