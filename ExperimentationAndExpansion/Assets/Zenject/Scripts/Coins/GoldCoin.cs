using UnityEngine;

namespace Zenject.Scripts.Coins
{
    public class GoldCoin : BaseCoin
    {
        #region Fields

        protected override CoinsEnum _coinsType { get;} = CoinsEnum.GoldCoin;

        #endregion

        public override void Init(CoinData coinData)
        {
            base.Init(coinData);
            _countInBag = _coinData.DefaultCoins;
        }
        
        public override void AddCoin()
        {
            _countInTable ++;
            _countInBag--;
            
            if (_countInTable + _countInBag >= _coinData.MaxCoinsCastUltimate)
            {
                Debug.Log("Wins");
            }
        }
    }
}