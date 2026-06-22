using Atomic.Entities;
using Game.UI;
using UnityEngine;

namespace Game.Gameplay
{
    public static class PlayerInputUseCase
    {
        public static void MoveWithJoystick(this IGameEntity player, Joystick joystick)
        {
            Vector3 direction = new Vector3(joystick.Direction.x, 0, joystick. Direction.y);
            player.GetValue(GameEntityAPI.MoveRequest).Invoke(direction);
        }
        
        public static void AttackWithJoystick(this IGameEntity player, Joystick joystick)
        {
            Vector3 direction = new Vector3(joystick.Direction.x, 0, joystick. Direction.y);
            player.GetValue(GameEntityAPI.IsAiming).Invoke(direction != Vector3.zero);
            
            if (direction == Vector3.zero)
                return;
            
            player.GetValue(GameEntityAPI.RotateRequest).Invoke(direction);
            player.GetValue(GameEntityAPI.AttackRequest).Invoke();   
        }
    }
}