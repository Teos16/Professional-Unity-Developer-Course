using Atomic.Entities;

/**
 * Created by Entity Domain Generator.
 */

namespace Game.Gameplay
{
    /// <summary>
    /// A prefab-based entity pool for managing <see cref="GameEntity"/> instances at runtime.
    /// </summary>
    /// <remarks>
    /// Useful for dynamically spawning and reusing <see cref="GameEntity"/> prefabs in gameplay scenes.
    /// </remarks>
    public sealed class GameEntityPrefabPool : PrefabEntityPool<GameEntity>
    {
    }
}
