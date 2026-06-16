using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static class GameContextAPI
    {
        public static ValueKey<IGameContext, IEntityPool<IGameEntity>> BulletPool = new(nameof(BulletPool));
        public static ValueKey<IGameContext, IReactiveVariable<int>> Score = new(nameof(Score));
        public static ValueKey<IGameContext, IGameEntity> Player = new(nameof(Player));
    }
}