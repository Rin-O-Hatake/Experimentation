using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Experimentation.MoneyProject.Scripts.Data.Interfaces;
using Experimentation.MoneyProject.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Zenject.Scripts.Coins;

namespace Experimentation.MoneyProject.Scripts
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        #region Fields

        [SerializeField] private BagView _bagView;

        [Title("Coins Data")] 
        [SerializeField] private CoinConfig _coinConfig;
        
        private BagManager _currentBagManager;

        #endregion
        
        public override void InstallBindings()
        {
            CreateAllCoins();

            InjectIShowCoins();
            CreateAndInjectBagManager();
            InjectIAddRandomCoins();
            InjectISaveCoins();

            InjectBagView();
        }

        private void InjectBagView()
        {
            Container.Bind<BagView>().FromInstance(_bagView).AsCached();
        }

        private void CreateAndInjectBagManager()
        {
            Container.Bind<BagManager>().FromNew().AsCached().NonLazy();
        }

        #region InjectCoins

        private void CreateAllCoins()
        {
            List<BaseCoin> _allCoins = new List<BaseCoin>();
            foreach (var coinType in Assembly.GetAssembly(typeof(BaseCoin)).GetTypes().Where(myType => myType.IsSubclassOf(typeof(BaseCoin))))
            {
                var coin = Activator.CreateInstance(coinType) as BaseCoin;
                if (coin == null)
                {
                    return;
                }
                
                coin.Init(_coinConfig.Coins.First(coinData => coinData.CoinType == coin.CoinsType));
                _allCoins.Add(coin);
            }
            
            Container.Bind<List<BaseCoin>>().FromInstance(_allCoins);
        }
        
        #endregion

        #region Interfaces

        private void InjectIAddRandomCoins()
        {
            Container.Bind<IAddRandomCoin>().To<BagManager>().AsTransient();
        }
        
        private void InjectISaveCoins()
        {
            Container.Bind<ISaveCoins>().To<BagManager>().AsTransient();
        }
        
        private void InjectIShowCoins()
        {
            Container.Bind<IShowCoins>().To<BagView>().FromInstance(_bagView);
        }

        #endregion
    }
}
