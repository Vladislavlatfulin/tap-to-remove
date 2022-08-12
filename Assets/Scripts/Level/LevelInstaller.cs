using System.Collections.Generic;
using Ads;
using Level.Blocks;
using Level.Blocks.Factory;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private CentralBaseBlockView _centralBlock;
        [SerializeField] private List<Transform> _spawnersList;
        [SerializeField] private InterstitialAds _ads;

        public override void InstallBindings()
        {
            BindBlocks();
            BindAds();
            BindFactory();
            BindPool();
            BindLevel();
        }

        private void BindAds()
        {
            Container.BindInstance(_ads);
        }

        private void BindLevel()
        {
            Container.BindInterfacesAndSelfTo<Level>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPool()
        {
            Container.BindInterfacesAndSelfTo<BlockPool>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFactory()
        {
            Container.BindInterfacesAndSelfTo<BlockFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBlocks()
        {
            Container.BindInstance(_centralBlock); // 

            Container.BindInstance(_blockPrefab)
                .WhenInjectedInto<IBlockFactory>();

            Container.Bind<List<Transform>>().FromInstance(_spawnersList);
        }
    }
}