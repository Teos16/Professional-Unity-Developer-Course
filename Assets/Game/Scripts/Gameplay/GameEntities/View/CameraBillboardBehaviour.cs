using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CameraBillboardBehaviour : IGameEntityInit, IGameEntityLateTick
    {
        private readonly IGameContext _gameContext;
        private readonly Transform _target;
        private Transform _camera;

        public CameraBillboardBehaviour(IGameContext gameContext, Transform target)
        {
            _gameContext = gameContext;
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        public void Init(IGameEntity entity)
        {
            TeamType team = entity.GetTeam().Value;
            IPlayerContext playerContext = _gameContext.GetPlayers()[team];
            _camera = playerContext.GetValue(PlayerContextAPI.Camera).transform;
        }

        public void LateTick(IGameEntity entity, float deltaTime)
        {
            Vector3 dir = _target.position - _camera.position;
            _target.rotation = Quaternion.LookRotation(dir, _camera.up);
        }
    }
}