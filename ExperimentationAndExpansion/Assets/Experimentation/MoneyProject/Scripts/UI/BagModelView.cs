using UnityEngine;
using Zenject;
using Zenject.Scripts.Coins;

namespace Experimentation.MoneyProject.Scripts.UI
{
    public class BagModelView : MonoBehaviour
    {
        #region Fields
        
        protected BagView _view;
        protected BagManager _bagManager;

        #endregion

        [Inject]
        public void Construct(BagView bagView, BagManager bagManager)
        {
            _bagManager = bagManager;
            _view = bagView;
            InjectCoins();
        }

        protected void InjectCoins()
        {
            (_bagManager[CoinsEnum.WoodCoin] as WoodenCoin)?.InitCoinActions(CastSkillWood);
            (_bagManager[CoinsEnum.BlackCoin] as BlackCoin)?.InitCoinActions(CastSkillBlack, CastUltimateBlack);
            (_bagManager[CoinsEnum.GoldCoin] as GoldCoin)?.InitCoinAction(CastSkillGold, CastUltimateGold);
        }

        #region Skills/Ultimates

        #region Skills

        protected void CastSkillWood()
        {
            _view.WoodCoinSkill();
        }

        protected void CastSkillBlack()
        {
            _bagManager.EndSetCoin(false);
            _view.BlackCoinSkill();
        }

        protected void CastSkillGold(int count, GoldCoin goldCoin)
        {
            _view.GoldCoinSkill(count, goldCoin);
        }


        #endregion

        #region Ultimates

        protected void CastUltimateGold()
        {
            _view.WinsOpenPanel();
        }
        
        protected void CastUltimateBlack()
        {
            _view.LoseOpenPanel();
        }

        #endregion
        
        #endregion
    }
}
