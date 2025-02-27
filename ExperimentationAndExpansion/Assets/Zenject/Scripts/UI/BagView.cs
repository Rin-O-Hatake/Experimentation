using System;
using System.Collections.Generic;
using Plugins.AltoCityUIPack.Scripts.Button;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts.UI
{
    public class BagView : MonoBehaviour
    {
        #region Fields
        
        [Title("Buttons")]
        [SerializeField] private UIButtonManagerCustom _buttonAddRandomCoin;
        [SerializeField] private UIButtonManagerCustom _buttonEndSet;

        [Title("Contents")]
        [SerializeField] private GameObject _bagContent;
        [SerializeField] private CoinUIView _coinUIPrefab;

        private List<CoinUIView> _allCoins = new List<CoinUIView>();
        
        private Action _endSetButton;
        private Action<Action<BaseCoin>> _addRandomCoinButton;

        
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

        public void Initialize(Action<Action<BaseCoin>> addRandomCoinButton, Action endSetButton)
        {
            _addRandomCoinButton = addRandomCoinButton;
            _endSetButton = endSetButton;
        }

        private void CreateCoins(BaseCoin baseCoin)
        {
            CoinUIView coinUIView = Instantiate(_coinUIPrefab, _bagContent.transform);
            coinUIView.InitCoinUIView(baseCoin.CoinData.Icon, baseCoin.CoinsType);
            _allCoins.Add(coinUIView);
        }
        
        public void RemoveAllCoins()
        {
            foreach (var coin in _allCoins)
            {
                Destroy(coin.gameObject);
            }
            
            _allCoins.Clear();
        }
        
        #region Buttons

        private void AddRandomCoinButton()
        {
            _addRandomCoinButton?.Invoke(CreateCoins);
        }

        private void EndSetButton()
        {
            _endSetButton?.Invoke();
        }
        #endregion

        #region Skills

        public void WoodCoinSkill()
        {
            _allCoins.RemoveAll(coin => coin.CoinType == CoinsEnum.WoodCoin);
        }

        public void BlackCoinSkill()
        {
            RemoveAllCoins();
        }
        
        #endregion
    }
}
