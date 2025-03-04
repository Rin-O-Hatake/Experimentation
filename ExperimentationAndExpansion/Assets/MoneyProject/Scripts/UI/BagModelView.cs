using System;
using System.Linq;
using MVVM;
using Zenject;
using Zenject.Scripts;
using Zenject.Scripts.Coins;

namespace MoneyProject.Scripts.UI
{
    public class BagModelView
    {
        #region Fields

        private BagView _view;
        private BagManager _bagManager;

        #endregion

        [Inject]
        public void Construct(BagView bagView, BagManager bagManager)
        {
            _bagManager = bagManager;
            _view = bagView;
            // InitView();
            InjectCoins();
        }

        [Method("OnBuyClick")]
        public void Button()
        {
            
        }

        // private void InitView()
        // {
        //     _view.Initialize(_bagManager.AddRandomCoin, _bagManager.EndSetCoin);
        // }

        private void InjectCoins()
        {
            (_bagManager.AllCoins.First(coin => coin.CoinsType == CoinsEnum.WoodCoin) as WoodenCoin)?.InitCoinActions(CastSkillWood);
            (_bagManager.AllCoins.First(coin => coin.CoinsType == CoinsEnum.BlackCoin) as BlackCoin)?.InitCoinActions(CastSkillBlack, CastUltimateBlack);
            (_bagManager.AllCoins.First(coin => coin.CoinsType == CoinsEnum.GoldCoin) as GoldCoin)?.InitCoinAction(CastSkillGold, CastUltimateGold);
        }

        #region Skills/Ultimates

        #region Skills

        private void CastSkillWood()
        {
            _view.WoodCoinSkill();
        }

        private void CastSkillBlack()
        {
            _bagManager.EndSetCoin(false);
            _view.BlackCoinSkill();
        }

        private void CastSkillGold(int count, GoldCoin goldCoin)
        {
            _view.GoldCoinSkill(count, goldCoin);
        }


        #endregion

        #region Ultimates

        private void CastUltimateGold()
        {
            _view.WinsOpenPanel();
        }

        private void CastUltimateBlack()
        {
            _view.LoseOpenPanel();
        }

        #endregion
        
        #endregion
    }
}
