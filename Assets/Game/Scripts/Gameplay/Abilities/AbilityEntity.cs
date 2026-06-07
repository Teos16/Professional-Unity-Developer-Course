using Atomic.Entities;
using System.Collections.Generic;

/**
 * Created by Entity Domain Generator.
 */

namespace Game.Gameplay
{
    /// <summary>
    /// Represents the core implementation of an <see cref="IAbilityEntity"/> in the framework.
    /// This class follows the Entity–State–Behaviour pattern, providing a modular container
    /// for dynamic state, tags, behaviours, and lifecycle management.
    /// </summary>
    public sealed class AbilityEntity : Entity, IAbilityEntity
    {
        /// <summary>
        /// Creates a new entity with the specified name, tags, values, behaviours, and optional settings.
        /// </summary>
        public AbilityEntity(
            string name,
            IEnumerable<string> tags,
            IEnumerable<KeyValuePair<string, object>> values,
            IEnumerable<IEntityBehaviour> behaviours,
            Settings? settings = null
        ) : base(name, tags, values, behaviours, settings)
        {
        }

        /// <summary>
        /// Creates a new entity with the specified name, tags, values, behaviours, and optional settings.
        /// </summary>
        public AbilityEntity(
            string name,
            IEnumerable<int> tags,
            IEnumerable<KeyValuePair<int, object>> values,
            IEnumerable<IEntityBehaviour> behaviours,
            Settings? settings = null
        ) : base(name, tags, values, behaviours, settings)
        {
        }

        /// <summary>
        /// Creates a new entity with the specified name and initial capacities for tags, values, and behaviours.
        /// </summary>
        public AbilityEntity(
            string name = null,
            int tagCapacity = 0,
            int valueCapacity = 0,
            int behaviourCapacity = 0,
            Settings? settings = null
        ) : base(name, tagCapacity, valueCapacity, behaviourCapacity, settings)
        {
        }
    }
}
