namespace Zenject.Scripts.Coins
{
    public interface ISkillCoin
    {
        public void TriggeringSkillCoin();
    }
    
    public interface IRemoveCoin
    {
        public void RemoveCoin(int count);
    }
    
    public interface ISetCoin
    {
        public void SetCoin(int amount);
    }

}
