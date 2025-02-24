using UnityEngine;
using Zenject.Scripts.Coins;

namespace Zenject.Scripts
{
    public class BagManager : MonoBehaviour
    {
        #region Fields

        private GoldCoin _goldCoin;
        private BlackCoin _blackCoin;
        private WoodenCoin _woodenCoin;

        #endregion

        [Inject]
        public void Construct(GoldCoin goldCoin, BlackCoin blackCoin, WoodenCoin woodenCoin)
        {
            _goldCoin = goldCoin;
            _blackCoin = blackCoin;
            _woodenCoin = woodenCoin;
            Debug.Log($"{_goldCoin == null}  {_blackCoin == null}  {_woodenCoin == null}");
        }
    }
}
