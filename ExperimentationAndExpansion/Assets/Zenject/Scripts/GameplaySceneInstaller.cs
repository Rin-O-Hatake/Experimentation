
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        #region Fields

        [SerializeField] private BagManager _bagManagerPrefab;

        [Title("Coins Data")] 
        [SerializeField] private CoinConfig _coinConfig; 

        #endregion
        
        public override void InstallBindings()
        {
            CreateAllCoins();
            CreateAndInjectBagManager();
        }

        private void CreateAndInjectBagManager()
        {
            BagManager bagManager = Container.InstantiatePrefabForComponent<BagManager>(_bagManagerPrefab);
            Container.Bind<BagManager>().FromInstance(bagManager);
        }

        #region InjectCoins

        private void CreateAllCoins()
        {
            CreateAndInjectGoldenCoin();
            CreateAndInjectDeathCoin();
            CreateAndInjectWoodCoin();
        }

        private void CreateAndInjectWoodCoin()
        {
            CoinData coinData = _coinConfig.Coins.First(coin => coin.CoinType == CoinsEnum.WoodCoin);
            WoodenCoin woodCoin = new WoodenCoin(coinData.DefaultCoins, coinData.MaxCoinsCastSkill);
            InjectCoin(woodCoin);
        }

        private void CreateAndInjectDeathCoin()
        {
            CoinData coinData = _coinConfig.Coins.First(coin => coin.CoinType == CoinsEnum.BlackCoin);
            BlackCoin blackCoin = new BlackCoin(coinData.DefaultCoins, coinData.MaxCoinsCastSkill, coinData.MaxCoinsCastUltimate);
            InjectCoin(blackCoin);
        }

        private void CreateAndInjectGoldenCoin()
        {
            CoinData coinData = _coinConfig.Coins.First(coin => coin.CoinType == CoinsEnum.GoldCoin);
            GoldCoin goldCoin = new GoldCoin(coinData.DefaultCoins, coinData.MaxCoinsCastUltimate);
            InjectCoin(goldCoin);
        }

        private void InjectCoin<T>(T typeCoin) where T : BaseCoin
        {
            Container.Bind<T>().FromInstance(typeCoin);
            Container.Bind<BaseCoin>().To<T>().AsSingle();
        }

        #endregion
    }
}
