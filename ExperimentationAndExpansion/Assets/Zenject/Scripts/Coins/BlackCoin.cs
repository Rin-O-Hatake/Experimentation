using UnityEngine;

namespace Zenject.Scripts.Coins
{
    public class BlackCoin : BaseCoin, ISkillCoin
    {
        #region Field

        protected override int _count { get; set; }
        protected override int _defaultCoins { get; set; }
        protected int _maxCoinsCastUltimate;
        protected int _maxCoinsCastSkills;

        #endregion

        #region Overload

        public BlackCoin(int defaultCoins, int maxCoinsCastUltimate, int maxCoinsCastSkills)
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

        public void TriggeringSkillCoin()
        {
            Debug.Log("Game over");
        }
    }
}
