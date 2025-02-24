namespace Zenject.Scripts
{
    public abstract class BaseCoin
    {
        protected abstract int _count { get; set;}
        protected abstract int _defaultCoins { get; set; }

        public abstract void SetCoin(int count = 1);
    }
}
