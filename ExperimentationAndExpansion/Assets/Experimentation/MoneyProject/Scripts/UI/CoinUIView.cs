using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject.Scripts.Coins;

namespace MoneyProject.Scripts.UI
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

        public void FadeOutCoin()
        {
            _image.DOFade(0, 2)
                .OnComplete(DestroyCoinUIView);
        }

        private void DestroyCoinUIView()
        {
            Destroy(gameObject);
        }
    }
}
