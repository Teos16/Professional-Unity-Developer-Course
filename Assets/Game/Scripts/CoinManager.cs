using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;

namespace Game
{
    public sealed class CoinManager
    {
        public event Action<ICoin> OnCoinPickedUp;
        public event Action OnAllCoinsPickedUp;

        private readonly CoinSpawner _coinSpawner;
        
        private List<ICoin> _coins;

        public CoinManager(CoinSpawner coinSpawner) => _coinSpawner = coinSpawner;

        public void SpawnCoins(int count)
        {
            _coins = new List<ICoin>(count);
            
            for (int i = 0; i < count; i++)
            {
                ICoin coin = _coinSpawner.SpawnCoin();
                _coins.Add(coin);
            }
        }

        public bool TryPickUpCoinAt(Vector2Int position)
        {
            for (int i = _coins.Count - 1; i >= 0; i--)
            {
                ICoin coin = _coins[i];
                
                if (position == coin.Position)
                {
                    PickUpCoin(i, coin);
                    return true;
                }
            }
            return false;
        }

        private void PickUpCoin(int i, ICoin coin)
        {
            _coins.RemoveAt(i);
            OnCoinPickedUp?.Invoke(coin);
            _coinSpawner.DespawnCoin(coin);

            if (_coins.Count == 0)
                OnAllCoinsPickedUp?.Invoke();
        }
    }
}