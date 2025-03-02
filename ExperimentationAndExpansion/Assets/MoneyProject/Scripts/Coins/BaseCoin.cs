namespace Zenject.Scripts.Coins
{
    public abstract class BaseCoin
    {
        protected abstract CoinsEnum _coinsType{ get;}
        protected int _countInTable;
        protected int _countInBag;
        protected CoinData _coinData;

        #region Properties

        public CoinData CoinData => _coinData;
        public int CountCoins => _countInBag;
        public CoinsEnum CoinsType => _coinsType;

        #endregion
        public abstract void AddCoin();

        public virtual void Init(CoinData coinData)
        {
            _coinData = coinData;
        }

        public virtual void ResetCoins(bool stateIsEndState = true)
        {
            _countInBag += _countInTable;
            _countInTable = 0;
        }
    }
}
