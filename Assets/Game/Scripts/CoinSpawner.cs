using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class CoinSpawner
    {
        private readonly MemoryPool<Coin> _coinPool;
        private readonly IWorldBounds _worldBounds;

        public CoinSpawner(MemoryPool<Coin> coinPool, IWorldBounds worldBounds)
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
        }

        public ICoin SpawnCoin()
        {
            Coin coin = _coinPool.Spawn();
            coin.Position = _worldBounds.GetRandomPosition();
            coin.Generate();
            coin.gameObject.SetActive(true);
            return coin;
        }

        public void DespawnCoin(ICoin coin)
        {
            if (coin is Coin concreteCoin)
            {
                concreteCoin.gameObject.SetActive(false);
                _coinPool.Despawn(concreteCoin);
            }
        }
    }
}