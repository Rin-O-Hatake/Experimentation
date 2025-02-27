using System;
using System.Linq;
using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts.UI
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
            InitView();
        }

        protected void InitView()
        {
            _view.Initialize(_bagManager.AddRandomCoin, _bagManager.EndSetCoin);
        }

        protected void InjectCoins()
        {
            (_bagManager.AllCoins.First(coin => coin.CoinsType == CoinsEnum.WoodCoin) as WoodenCoin)?.InitCoinActions(CastSkillWood);
            (_bagManager.AllCoins.First(coin => coin.CoinsType == CoinsEnum.BlackCoin) as BlackCoin)?.InitCoinActions(CastSkillBlack);
        }

        #region Skills/Ultimates

        protected void CastSkillWood()
        {
            _view.WoodCoinSkill();
        }

        protected void CastSkillBlack()
        {
            _view.BlackCoinSkill();
        }

        #endregion
    }
}
