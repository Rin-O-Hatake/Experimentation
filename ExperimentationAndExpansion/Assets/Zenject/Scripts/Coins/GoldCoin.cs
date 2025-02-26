using UnityEngine;

namespace Zenject.Scripts.Coins
{
    public class GoldCoin : BaseCoin
    {
        #region Fields
        
        protected sealed override int _defaultCoins { get; set; }

        protected int _maxCoinsCastUltimate;
        
        #endregion

        #region OverLoad

        public GoldCoin(int defaultCoins, int maxCoinsCastUltimate)
        {
            _maxCoinsCastUltimate = maxCoinsCastUltimate;
            _defaultCoins = defaultCoins;
        }

        #endregion

        public override void AddCoin()
        {
            _countInTable ++;
            if (_countInTable >= _maxCoinsCastUltimate)
            {
                ((ISkillCoin)this).TriggeringSkillCoin();
            }
        }
    }
}