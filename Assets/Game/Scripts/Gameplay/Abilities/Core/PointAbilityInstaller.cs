using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class PointAbilityInstaller
    {
        [SerializeField]
        private KeyCode _keyCode;
        
        public void Install(IAbilityEntity ability, IPlayerContext playerContext)
        {
            ability.AddPointRequest(new Request<Vector3>());
            ability.AddPointCommand(new Command<Vector3>());
            ability.WhenTick(_ =>
            {
                if (Input.GetKey(_keyCode) && Input.GetMouseButtonDown(0) &&
                    playerContext.RaycastGround(Input.mousePosition, out Vector3 point))
                    ability.GetPointRequest().Invoke(point);
            });
            ability.WhenFixedTick(_ =>
            {
                if (ability.GetPointRequest().Consume(out Vector3 point))
                    ability.GetPointCommand().Invoke(point);
            });
        }
    }
}