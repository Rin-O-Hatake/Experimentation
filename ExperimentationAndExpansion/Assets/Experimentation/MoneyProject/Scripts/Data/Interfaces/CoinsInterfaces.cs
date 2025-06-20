using Zenject.Scripts.Coins;

namespace Experimentation.MoneyProject.Scripts.Data.Interfaces
{
    public interface IAddRandomCoin
    {
        void AddRandomCoin();
    }

    public interface ISaveCoins
    {
        void SaveCoins();
    }

    public interface IShowCoins
    {
        void ShowCoins(BaseCoin coin);
    }

    public interface ICastSkillView
    {
        void WoodCoinView();
    }
}
