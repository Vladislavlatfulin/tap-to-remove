using UnityEngine;
using Zenject;

namespace Level.Blocks.Factory
{
    public class BlockFactory : IBlockFactory
    {
        private DiContainer _diContainer;
        private GameObject _blockPrefab;

        [Inject]
        public BlockFactory(
            DiContainer diContainer,
            GameObject prefab
        )
        {
            _diContainer = diContainer;    
            _blockPrefab = prefab;
        }
        
        public BaseBlockView Create()
        {
            BaseBlockView blockView = _diContainer.InstantiatePrefabForComponent<BaseBlockView>(_blockPrefab);
            blockView.gameObject.SetActive(false);
            return blockView;
        }
    }
}