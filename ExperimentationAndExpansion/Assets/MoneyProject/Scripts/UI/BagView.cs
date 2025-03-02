using System;
using System.Collections.Generic;
using Plugins.AltoCityUIPack.Scripts.Button;
using Sirenix.OdinInspector;
using UnityEngine;
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
        [SerializeField] private Transform _bagContent;
        [SerializeField] private Transform _saveContent;
        [SerializeField] private CoinUIView _coinUIPrefab;

        [Title("View State Game")] 
        [SerializeField] private GameObject _gameWin;
        [SerializeField] private GameObject _gameLose;
        
        private List<CoinUIView> _allCoins = new List<CoinUIView>();
        
        private Action<bool> _endSetButton;
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

        public void Initialize(Action<Action<BaseCoin>> addRandomCoinButton, Action<bool> endSetButton)
        {
            _addRandomCoinButton = addRandomCoinButton;
            _endSetButton = endSetButton;
        }

        private void ShowCoinsInTable(BaseCoin baseCoin)
        {
            var coinUIView = CreateCoin(baseCoin);
            _allCoins.Add(coinUIView);
        }

        private CoinUIView CreateCoin(BaseCoin baseCoin, Transform container = null)
        {
            CoinUIView coinUIView = Instantiate(_coinUIPrefab, container == null ? _bagContent : container.transform);
            coinUIView.InitCoinUIView(baseCoin.CoinData.Icon, baseCoin.CoinsType);
            return coinUIView;
        }


        public void RemoveAllCoins()
        {
            foreach (var coin in _allCoins)
            {
                if (coin == null)
                {
                    continue;
                }
                
                Destroy(coin.gameObject);
            }
            
            _allCoins.Clear();
        }
        
        #region Buttons

        private void AddRandomCoinButton()
        {
            _addRandomCoinButton?.Invoke(ShowCoinsInTable);
        }

        private void EndSetButton()
        {
            _endSetButton?.Invoke(true);
            RemoveAllCoins();
        }
        #endregion

        #region Skills

        public void WoodCoinSkill()
        {
            foreach (var coin in _allCoins.FindAll(coin => coin.CoinType == CoinsEnum.WoodCoin))
            {
                coin.FadeOutCoin();
            }
            
            _allCoins.RemoveAll(coin => coin == null);
            
            foreach (var coin in _allCoins)
            {
                Debug.Log(coin.CoinType.ToString());
            }
        }

        public void BlackCoinSkill()
        {
            RemoveAllCoins();
        }

        public void GoldCoinSkill(int count, GoldCoin goldCoin)
        {
            for (int index = 0; index < count; index++)
            {
                CreateCoin(goldCoin, _saveContent);    
            }
        }
        
        #endregion

        #region Ultimates

        public void WinsOpenPanel()
        {
            _gameWin.SetActive(true);
        }
        
        public void LoseOpenPanel()
        {
            _gameLose.SetActive(true);
        }

        #endregion
    }
}
