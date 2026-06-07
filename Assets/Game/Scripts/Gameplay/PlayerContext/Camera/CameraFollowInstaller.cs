using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CameraFollowController : IPlayerContextInit, IPlayerContextLateTick
    {
        private readonly IValue<Vector3> _offset;
        private IGameEntity _character;
        private Camera _camera;

        public CameraFollowController(IValue<Vector3> offset)
        {
            _offset = offset;
        }

        public void Init(IPlayerContext context)
        {
            _character = context.GetValue(PlayerContextAPI.Character);
            _camera = context.GetValue(PlayerContextAPI.Camera);
        }

        public void LateTick(IPlayerContext entity, float deltaTime)
        {
            _camera.transform.position = _character.GetPosition().Value + _offset.Value;
        }
    }
}