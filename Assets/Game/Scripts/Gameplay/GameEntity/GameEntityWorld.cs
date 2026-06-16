using Atomic.Entities;

/**
 * Created by Entity Domain Generator.
 */

namespace Game.Gameplay
{
    /// <summary>
    /// A Unity-integrated world manager that handles all <see cref="GameEntity"/> entities in the current scene.
    /// </summary>
    /// <remarks>
    /// This component hooks into Unity’s lifecycle (Awake, OnEnable, Update, OnDisable, etc.) to automatically
    /// manage creation, updates, and disposal of <see cref="GameEntity"/> entities at runtime.
    /// </remarks>
    /// <example>
    /// Attach this component to a GameObject in your scene to automatically discover and manage all <see cref="GameEntity"/> entities.
    /// </example>
    public sealed class GameEntityWorld : SceneEntityWorld<GameEntity>
    {
    }
}
