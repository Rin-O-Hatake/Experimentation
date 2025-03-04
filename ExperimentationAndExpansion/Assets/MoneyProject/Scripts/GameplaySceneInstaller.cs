
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MoneyProject.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        #region Fields

        [SerializeField] private BagManager _bagManagerPrefab;
        [SerializeField] private BagView _bagView;

        [Title("Coins Data")] 
        [SerializeField] private CoinConfig _coinConfig; 

        #endregion
        
        public override void InstallBindings()
        {
            CreateAllCoins();
            CreateAndInjectBagManager();
            InjectBagView();
        }

        private void InjectBagView()
        {
            Container.Bind<BagView>().FromInstance(_bagView).AsSingle();
        }

        private void CreateAndInjectBagManager()
        {
            BagManager bagManager = Container.InstantiatePrefabForComponent<BagManager>(_bagManagerPrefab);
            Container.Bind<BagManager>().FromInstance(bagManager);
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
    }
}
