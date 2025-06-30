using System;
using UnityEngine;
using Zenject.Scripts.Coins;

namespace Experimentation.MoneyProject.Scripts.Coins
{
    public class GoldCoin : BaseCoin
    {
        #region Fields

        protected override CoinsEnum _coinsType { get;} = CoinsEnum.GoldCoin;
        protected int _countCoinsSave;

        protected Action<int, GoldCoin> _castSkillAction;
        protected Action _castUltimateAction;
        
        #endregion

        #region Inits

        public override void Init(CoinData coinData)
        {
            base.Init(coinData);
            _countInBag = _coinData.DefaultCoins;
        }

        public void InitCoinAction(Action<int, GoldCoin> castSkillAction, Action castUltimateAction)
        {
            _castUltimateAction = castUltimateAction;
            _castSkillAction = castSkillAction;
        }
        
        #endregion
        
        public override void AddCoin()
        {
            _countInTable ++;
            _countInBag--;
            
            if (_countInTable + _countCoinsSave >= _coinData.MaxCoinsCastUltimate)
            {
                ResetCoins();
                _castUltimateAction?.Invoke();
                Debug.Log("Wins");
            }
        }

        public override void ResetCoins(bool stateIsEndState = true)
        {
            if (stateIsEndState)
            {
                _castSkillAction?.Invoke(_countInTable, this);
                _countCoinsSave += _countInTable;
                _countInTable = 0;
            }
            
            base.ResetCoins(stateIsEndState);
        }
    }
}