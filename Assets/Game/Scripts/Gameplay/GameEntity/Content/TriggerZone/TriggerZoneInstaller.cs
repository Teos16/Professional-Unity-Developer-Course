using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TriggerZoneInstaller : GameEntityInstaller
    {
        [SerializeField] private GameEntity[] _zombies;
        [SerializeField] private TriggerEvents _triggerEvents;
            
        public override void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Agents, new Variable<IGameEntity[]>(_zombies));
            entity.AddValue(GameEntityAPI.TriggerEvents, _triggerEvents);
            entity.AddBehaviour(new SetTargetForAgentsBehaviour());
        }
    }
}