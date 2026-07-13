using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class PlayerInputUseCase
    {
        public static void Move(this IGameEntity player, Vector3 direction) => 
            player.GetValue(GameEntityAPI.MoveRequest).Invoke(direction);

        public static void Attack(this IGameEntity player, Vector3 direction)
        {
            player.GetValue(GameEntityAPI.IsAiming).Invoke(direction != Vector3.zero);
            
            if (direction == Vector3.zero)
                return;
            
            player.GetValue(GameEntityAPI.RotateRequest).Invoke(direction);
            player.GetValue(GameEntityAPI.AttackRequest).Invoke();   
        }
    }
}