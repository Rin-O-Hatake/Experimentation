using System;
using UnityEngine;

namespace Zenject.Scripts.Coins
{
    public class WoodenCoin : BaseCoin, IRemoveCoin, ISetCoin
    {
        #region Fields

        protected override CoinsEnum _coinsType { get; } = CoinsEnum.WoodCoin;

        private Action _castSkillAction;

        #endregion

        #region Inits

        public override void Init(CoinData coinData)
        {
            base.Init(coinData);
            _countInBag = _coinData.DefaultCoins;
        }

        public void InitCoinActions(Action castSkillAction)
        {
            _castSkillAction = castSkillAction;
        }

        #endregion
        
        public override void AddCoin()
        {
            _countInTable ++;
            _countInBag--;
            
            if (_countInTable >= _coinData.MaxCoinsCastSkill)
            {
                RemoveCoin(_coinData.MaxCoinsCastSkill);
                _castSkillAction?.Invoke();
                
                Debug.Log("Cast skill wood coin: remove 2 coins");
            }
        }
        

        public void RemoveCoin(int count)
        {
            _countInTable -= count;
        }

        public void SetCoin(int amount)
        {
            _countInBag += amount;
        }
    }
}
