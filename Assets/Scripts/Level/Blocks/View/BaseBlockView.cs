using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UI;
using UnityEngine;
using Zenject;

namespace Level.Blocks
{
    public class BaseBlockView : MonoBehaviour, IDirectionMovable
    {
        public Vector2Int SwapDirection { get; set; }
        private TweenerCore<Vector3, Vector3, VectorOptions> _currentAnimation;
        private Level _level;

        [Inject]
        private void Constructor(Level level)
        {
            _level = level;
        }
        
        public void SwapMove(Vector2 finishPosition)
        {
            _currentAnimation.Kill();
            _currentAnimation = transform.DOMove(finishPosition, 1).
                SetRelative().OnComplete(OnInvisible);
        }

        public void MoveTo(Vector3 finishPosition, float duration)
        {
           _currentAnimation = transform.DOMove(finishPosition, duration).
               OnComplete(OnInvisible);
        }

        private void OnInvisible()
        {
            _level.CountSwappedBlocks += 1;
            gameObject.SetActive(false);
        }

        public void ResetSquareSettings()
        {
            gameObject.SetActive(false);
            _currentAnimation.Kill();
            _currentAnimation = null;
        }
    }
}
