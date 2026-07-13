using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DetectBehaviour : IGameEntityInit, IGameEntityFixedTick, IGameEntityGizmos
    {
        private IVariable<IGameEntity> _target;

        private readonly Transform _center;
        private readonly float _radius;
        private readonly LayerMask _layerMask;
        private readonly Cooldown _period;

        public DetectBehaviour(
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

        public void Init(IGameEntity entity) => _target = entity.GetValue(GameEntityAPI.Target);

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            _period.Tick(deltaTime);
            if (!_period.IsCompleted())
                return;

            TargetUseCase.TryFindClosest(
                _center.position,
                _radius,
                _layerMask,
                out IGameEntity target,
                entity.GetValue(GameEntityAPI.TargetDetectionType)
            );

            _target.Value = target;
            _period.ResetTime();
        }
        
        public void DrawGizmos(IGameEntity entity) => Gizmos.DrawWireSphere(_center.position, _radius);
    }
}