using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class DetectInteractibleBehaviour : IEntityInit, IEntityFixedTick, IEntityGizmos
    {
        private IVariable<IEntity> _target;

        private readonly Transform _center;
        private readonly float _radius;
        private readonly LayerMask _layerMask;
        private readonly Cooldown _period;

        public DetectInteractibleBehaviour(
            Transform center,
            float radius,
            LayerMask layerMask,
            Cooldown period
        )
        {
            _center = center;
            _radius = radius;
            _layerMask = layerMask;
            _period = period;
        }

        public void Init(IEntity entity)
        {
            _target = entity.GetTargetInteractible();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            _period.Tick(deltaTime);
            if (!_period.IsCompleted())
                return;

            TargetUseCase.FindClosest(
                _center.position,
                _radius,
                _layerMask,
                out IEntity target,
                InteractUseCase.IsInteractible
            );

            _target.Value = target;
            _period.ResetTime();
        }

        public void DrawGizmos(IEntity entity)
        {
            Gizmos.DrawWireSphere(_center.position, _radius);
        }
    }
}