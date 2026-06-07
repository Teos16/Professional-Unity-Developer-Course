using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class JumpEntityAspect : IGameEntityAspect
    {
        [SerializeField]
        private float _force = 5;

        [SerializeField]
        private float _cooldown = 1;

        public void Apply(IGameEntity entity)
        {
            entity.AddJumpForce(new Variable<float>(_force));
            entity.AddJumpCooldown(new Cooldown(_cooldown, 0));
            entity.AddJumpRequest(new Request());
            entity.AddJumpCommand(new Command()
                .AddCondition(entity.IsGrounded)
                .AddCondition(entity.GetJumpCooldown().IsCompleted)
                .AddAction(entity.Jump)
                .AddAction(entity.GetJumpCooldown().ResetTime)
            );
            
            entity.AddBehaviour<JumpRequestBehaviour>();
            entity.AddBehaviour<JumpCooldownBehaviour>();
            entity.AddBehaviour<JumpInputController>();
            entity.AddBehaviour<JumpAnimBehaviour>();
        }

        public void Discard(IGameEntity entity)
        {
            entity.DelBehaviour<JumpRequestBehaviour>();
            entity.DelBehaviour<JumpInputController>();
            entity.DelBehaviour<JumpCooldownBehaviour>();
            entity.DelBehaviour<JumpAnimBehaviour>();
            
            entity.DelJumpRequest();
            entity.DelJumpCommand();
            entity.DelJumpForce();
            entity.DelJumpCooldown();
        }
    }
}