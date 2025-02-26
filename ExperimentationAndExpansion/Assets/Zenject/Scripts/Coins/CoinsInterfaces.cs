namespace Zenject.Scripts.Coins
{
    public interface ISkillCoin
    {
        public void TriggeringSkillCoin();
    }
    
    public interface IRemoveCoin
    {
        public void RemoveCoin();
    }
    
    public interface ISetCoin
    {
        public void SetCoin(int amount);
    }

}
