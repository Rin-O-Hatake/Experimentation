using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject.Scripts.Coins;
using Random = UnityEngine.Random;

namespace Zenject.Scripts
{
    public class BagManager : MonoBehaviour
    {
        #region Fields
        
        private BaseCoin[] _allCoins;

        #region Properties

        public BaseCoin[] AllCoins => _allCoins;

        #endregion

        #endregion

        [Inject]
        public void Construct(List<BaseCoin> allCoins)
        {
            _allCoins = allCoins.ToArray();
        }

        public void AddRandomCoin(Action<BaseCoin> createCoin)
        {
            BaseCoin baseCoin = RandomCoin();

            if (baseCoin == null)
            {
                Debug.Log("We're out of coins");
                return;    
            }
            
            baseCoin.AddCoin();
            createCoin?.Invoke(baseCoin);

            return;

            BaseCoin RandomCoin()
            {
                List<BaseCoin> baseCoins = new List<BaseCoin>();
                foreach (var coins in _allCoins)
                {
                    for (int index = 0; index < coins.CountCoins; index++)
                    {
                        baseCoins.Add(coins);
                    }   
                }

                if (baseCoins.Count == 0)
                {
                    return null;
                }
                
                int randomCoin = Random.Range(0, baseCoins.Count - 1);
                return baseCoins[randomCoin];
            }
        }

        public void EndSetCoin()
        {
            foreach (var coin in _allCoins)
            {
                
            }
        }
    }
}
