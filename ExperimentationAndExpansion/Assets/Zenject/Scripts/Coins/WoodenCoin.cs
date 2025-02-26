namespace Zenject.Scripts.Coins
{
    public class WoodenCoin : BaseCoin, IRemoveCoin, ISetCoin
    {
        #region Field
        
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

        public override void AddCoin()
        {
            _countInTable ++;   
        }
        

        public void RemoveCoin()
        {
            _countInTable --;
        }

        public void SetCoin(int amount)
        {
            _countInBag += amount;
        }
    }
}
