using UnityEngine;

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
        }

        protected void InitView()
        {
            _view.Initialize(_bagManager.AddRandomCoin, _bagManager.EndSetCoin);
        }
    }
}
