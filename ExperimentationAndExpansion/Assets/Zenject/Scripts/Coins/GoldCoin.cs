using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts
{
    public class GoldCoin : BaseCoin, ISkillCoin
    {
        #region Fields

        protected override int _count { get; set; }

        protected sealed override int _defaultCoins { get; set; }

        protected int _maxCoinsCastUltimate;
        protected int _maxCoinsCastSkills;

        #endregion

        #region OverLoad

        public GoldCoin(int defaultCoins, int maxCoinsCastUltimate, int maxCoinsCastSkills)
        {
            _maxCoinsCastSkills = maxCoinsCastSkills;
            _maxCoinsCastUltimate = maxCoinsCastUltimate;
            _defaultCoins = defaultCoins;
        }

        #endregion

        public override void SetCoin(int count = 1)
        {
            _count += count;
            if (_count >= _maxCoinsCastUltimate)
            {
                ((ISkillCoin)this).TriggeringSkillCoin();
            }
        }
        
        void ISkillCoin.TriggeringSkillCoin()
        {
            Debug.Log("You have won, congratulations!");
        }
    }
}