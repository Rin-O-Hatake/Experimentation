using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts
{
    public class WoodenCoin : BaseCoin, IRemoveCoin
    {
        #region Field

        protected override int _count { get; set; }
        protected override int _defaultCoins { get; set; }

        private int _maxCoinsCastSkills;

        #endregion

        #region Overload

        public WoodenCoin(int defaultCoins, int maxCoinsCastSkills)
        {
            _maxCoinsCastSkills = maxCoinsCastSkills;
            _defaultCoins = defaultCoins;
        }

        #endregion
        
        public override void SetCoin(int count = 1)
            => _count += count;
        

        public void RemoveCoin()
        {
            _count --;
        }
    }
}
