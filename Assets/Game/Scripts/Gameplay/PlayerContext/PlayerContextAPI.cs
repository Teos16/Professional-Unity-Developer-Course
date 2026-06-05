using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class PlayerContextAPI
    {
        public static TagKey<IPlayerContext> PlayerTag = new(nameof(PlayerTag));
        public static ValueKey<IPlayerContext, Camera> Camera => new(nameof(Camera));
        public static ValueKey<IPlayerContext, IGameEntity> Character => new(nameof(Character));
        public static ValueKey<IPlayerContext, InputMap> InputMap => new(nameof(InputMap));
        public static ValueKey<IPlayerContext, ICooldown> RespawnCooldown => new(nameof(RespawnCooldown));
        public static ValueKey<IPlayerContext, IValue<TeamType>> Team => new(nameof(Team));
        public static ValueKey<IPlayerContext, IReactiveVariable<int>> Score => new(nameof(Score));
    }
}