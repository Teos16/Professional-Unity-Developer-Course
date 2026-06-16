using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class HealthPickUpInstaller : PickUpInstaller
    {
        [BoxGroup("SPECIFIC"), SerializeField] private int _health = 3;
        
        public override void Install(IGameEntity entity)
        {
            base.Install(entity);

            entity.GetValue(GameEntityAPI.InteractCommand)
                .AddCondition(target => target.HasTag(GameEntityAPI.PlayerTag))
                .AddCondition(target => target.IsAlive())
                .AddCondition(target => !target.IsHealthAtMax())
                .AddAction(target => target.AddHealth(_health))
                .AddAction(_ => entity.DelTag(GameEntityAPI.InteractableTag));
        }
    }
}