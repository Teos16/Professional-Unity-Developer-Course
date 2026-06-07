using UnityEngine;

namespace Game.Gameplay
{
    public static class CharacterUseCase
    {
        public static void RespawnCharacter(this IGameContext gameContext, IGameEntity character)
        {
            Transform spawnPoint = gameContext.NextSpawnPoint();
            character.GetPosition().Value = spawnPoint.position;
            character.GetRotation().Value = spawnPoint.rotation;
            character.GetRespawnCommand().Invoke();
        }
    }
}