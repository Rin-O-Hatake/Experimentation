using UnityEngine;
using UnityEngine.UI;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts.UI
{
    public class CoinUIView : MonoBehaviour
    {
        #region Field

        [SerializeField] private Image _image;
        private CoinsEnum _coinType;

        #region Properties

        public CoinsEnum CoinType => _coinType;

        #endregion

        #endregion

        public void InitCoinUIView(Sprite sprite, CoinsEnum coinType)
        {
            _coinType = coinType;
            _image.sprite = sprite;
        }
    }
}
