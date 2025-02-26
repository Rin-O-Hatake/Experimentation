using System;
using Plugins.AltoCityUIPack.Scripts.Button;
using UnityEngine;

namespace Zenject.Scripts.UI
{
    public class BagView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UIButtonManagerCustom _buttonAddRandomCoin;
        [SerializeField] private UIButtonManagerCustom _buttonEndSet;

        private Action _endSetButton;
        private Action _addRandomCoinButton;

        
        #endregion

        #region MonoBehavior

        private void Start()
        {
            _buttonAddRandomCoin.OnClick.AddListener(AddRandomCoinButton);
            _buttonEndSet.OnClick.AddListener(EndSetButton);
        }

        private void OnDestroy()
        {
            _buttonAddRandomCoin.OnClick.RemoveListener(AddRandomCoinButton);
            _buttonEndSet.OnClick.RemoveListener(EndSetButton);
        }

        #endregion

        public void Initialize(Action addRandomCoinButton, Action endSetButton)
        {
            _addRandomCoinButton = addRandomCoinButton;
            _endSetButton = endSetButton;
        }
        
        #region Buttons

        private void AddRandomCoinButton()
        {
            _addRandomCoinButton?.Invoke();
        }

        private void EndSetButton()
        {
            _endSetButton?.Invoke();
        }
        #endregion
    }
}
