using System.Collections.Generic;
using System.Linq;
using Level.Blocks.Factory;
using Zenject;

namespace Level.Blocks
{
        public class BlockPool : IBlockPool, IInitializable
        {
        private const int POOL_SIZE = 30;
        private List<BaseBlockView> _blockViewsMap;

        private IBlockFactory _factory;

        [Inject]
        public BlockPool(IBlockFactory factory)
        {
            _factory = factory;
        }
        
        public void Initialize()
        {
            _blockViewsMap = new List<BaseBlockView>();
            
            for (int i = 0; i < POOL_SIZE; i++)
            {
                var blockView = _factory.Create();
                _blockViewsMap.Add(blockView);
            }
        }
        
        public BaseBlockView Get()
        {
            var freeObjects = _blockViewsMap.Where(v => v.gameObject.activeInHierarchy == false).ToArray();
            return freeObjects.First();
        }

        public void DeactivationAllObject()
        {
            for (var index = 0 ; index < _blockViewsMap.Count; index++)
            {
                var block = _blockViewsMap[index];
                if (block.gameObject.activeInHierarchy)
                    block.ResetSquareSettings();
            }
        }

        public void Return(BaseBlockView blockView)
        {
            throw new System.NotImplementedException();
        }
    }
}