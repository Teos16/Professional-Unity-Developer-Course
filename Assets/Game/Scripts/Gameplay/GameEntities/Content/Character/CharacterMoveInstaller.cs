using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class CharacterMoveInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private MoveInstaller _moveInstaller;

        [SerializeField]
        private Const<float> _moveSpeed;

        [SerializeField]
        private LayerMask _obstacleLayerMask;

        [SerializeField]
        private float _obstacleCheckDistance = 0.5f;

        [SerializeField]
        private Vector3 _centerOffset = new(0, 0.5f, 0);

        public void Install(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            entity.GetMoveCondition().Add(_ => entity.DoesHealthExist());
            entity.GetMoveCondition().Add(_ => entity.GetCurrentTransport().Value == null);

            entity.GetMoveAction().Add((direction, deltaTime) =>
                entity.MoveStepWithObstacle(direction, deltaTime, _centerOffset, _obstacleCheckDistance, _obstacleLayerMask));
            entity.GetMoveAction().Add(entity.RotateStep);
            entity.AddMoveSpeed(_moveSpeed);
        }
    }
}