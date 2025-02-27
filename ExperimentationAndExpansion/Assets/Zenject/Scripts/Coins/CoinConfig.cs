using System;
using UnityEngine;
using UnityEngine.UI;

namespace Zenject.Scripts.Coins
{
    [CreateAssetMenu(order = 51, fileName = "Coins Config", menuName = "Experimentation/Zenject/CoinsData")]
    public class CoinConfig : ScriptableObject 
    {
        #region Fields

        [SerializeField] private CoinData[] _coins;

        #region Properties

        public CoinData[] Coins => _coins;

        #endregion

        #endregion
    }

    [Serializable]
    public class CoinData
    {
        #region Fields

        [SerializeField] private int _defaultCoins;
        [SerializeField] private int _maxCoinsCastUltimate;
        [SerializeField] private int _maxCoinsCastSkill;
        [SerializeField] private CoinsEnum _coinType;
        [SerializeField] private Sprite _icon;

        #region Properties

        
        public int DefaultCoins => _defaultCoins;
        public int MaxCoinsCastUltimate => _maxCoinsCastUltimate;
        public int MaxCoinsCastSkill => _maxCoinsCastSkill;
        public CoinsEnum CoinType => _coinType;
        public Sprite Icon => _icon;

        #endregion

        #endregion
    }
}
