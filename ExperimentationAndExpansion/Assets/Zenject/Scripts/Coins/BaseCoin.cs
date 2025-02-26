namespace Zenject.Scripts.Coins
{
    public abstract class BaseCoin
    {
        protected int _countInTable;
        protected int _countInBag;
        protected abstract int _defaultCoins { get; set; }

        
        public int CountCoins => _countInBag;
        
        public abstract void AddCoin();
    }
}
