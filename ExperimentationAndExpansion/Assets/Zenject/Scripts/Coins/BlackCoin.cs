using System;
using UnityEngine;

namespace Zenject.Scripts.Coins
{
    public class BlackCoin : BaseCoin, ISkillCoin
    {
        #region Fields

        protected override CoinsEnum _coinsType { get; } = CoinsEnum.BlackCoin;

        protected Action _castSkillAction;
        protected Action _castUltimateAction;
        
        #endregion

        #region Inits

        public void InitCoinActions(Action castSkill, Action castUltimateAction)
        {
            _castUltimateAction = castUltimateAction;
            _castSkillAction = castSkill;
        }

        public override void Init(CoinData coinData)
        {
            base.Init(coinData);
            _countInBag = _coinData.DefaultCoins;
        }
        
        #endregion

        public override void AddCoin()
        {
            _countInTable ++;
            _countInBag--;

            if (_countInTable >= _coinData.MaxCoinsCastSkill)
            {
                _castSkillAction?.Invoke();
                _countInBag++;
                
                Debug.Log("Cast skill black coin: add 1 coin in bag");
            }
            
            if (_countInTable + _countInBag >= _coinData.MaxCoinsCastUltimate)
            {
                ((ISkillCoin)this).TriggeringSkillCoin();
            }
        }

        public void TriggeringSkillCoin()
        {
            _castUltimateAction?.Invoke();
            Debug.Log("Game over");
        }
    }
}
