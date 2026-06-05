using UnityEngine;

namespace Game.Gameplay
{
    public static class CharacterUseCase
    {
        public static void RespawnCharacter(this IGameContext context, IGameEntity character)
        {
            Transform nextSpawnPoint = context.NextSpawnPoint();
            character.GetPosition().Value = nextSpawnPoint.position;
            character.GetRotation().Value = nextSpawnPoint.rotation;
            character.GetRespawnAction().Invoke();
        }
    }
}