using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class CharacterMoveInstaller : IGameEntityInstaller
    {
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private Variable<float> _moveSpeed;
        [SerializeField] private LayerMask _obstacleLayerMask;
        [SerializeField] private float _obstacleCheckDistance = 0.5f;
        [SerializeField] private Vector3 _centerOffset = new(0, 0.5f, 0);

        public void Install(IGameEntity entity)
        {
            _moveInstaller.Install(entity);

            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddCondition(_ => entity.GetCurrentTransport().Value == null)
                .AddCondition(_ => !entity.GetIsStunned().Value)
                .AddAction(args =>
                {
                    entity.MoveStepWithObstacle(
                        args.direction,
                        entity.GetMoveSpeed().Value * entity.GetMoveSpeedMultiplier().Value,
                        args.deltaTime,
                        _centerOffset,
                        _obstacleCheckDistance,
                        _obstacleLayerMask
                    );
                })
                .AddAction(args => entity.RotateStep(args.direction, args.deltaTime));

            entity.AddMoveSpeed(_moveSpeed);
            entity.AddMoveSpeedMultiplier(new FloatMulExpression());
        }
    }
}