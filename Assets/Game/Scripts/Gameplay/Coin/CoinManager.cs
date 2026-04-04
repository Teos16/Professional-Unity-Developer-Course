using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class CoinManager
    {
        public event Action<ICoin> OnCoinPickedUp;
        public event Action OnAllCoinsPickedUp;

        private readonly MemoryPool<Coin> _coinPool;
        private readonly IWorldBounds _worldBounds;

        private List<ICoin> _coins;

        public CoinManager(MemoryPool<Coin> coinPool, IWorldBounds worldBounds)
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
        }

        public void SpawnCoins(int count)
        {
            _coins = new(count);

            for (int i = 0; i < count; i++)
            {
                Coin coin = _coinPool.Spawn();
                coin.Position = _worldBounds.GetRandomPosition();
                coin.Generate();
                coin.gameObject.SetActive(true);

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

        private void PickUpCoin(int index, ICoin coin)
        {
            _coins.RemoveAt(index);
            OnCoinPickedUp?.Invoke(coin);
            DespawnCoin(coin);

            if (_coins.Count == 0)
                OnAllCoinsPickedUp?.Invoke();
        }

        private void DespawnCoin(ICoin coin)
        {
            if (coin is Coin concreteCoin)
            {
                concreteCoin.gameObject.SetActive(false);
                _coinPool.Despawn(concreteCoin);
            }
        }
    }
}