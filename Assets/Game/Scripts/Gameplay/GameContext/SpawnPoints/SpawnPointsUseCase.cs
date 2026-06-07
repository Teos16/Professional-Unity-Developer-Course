using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public static class SpawnPointsUseCase
    {
        public static Transform NextSpawnPoint(this IGameContext context)
        {
            List<Transform> freePoints = context.GetFreeSpawnPoints();
            if (freePoints.Count == 0) 
                freePoints.AddRange(context.GetAllSpawnPoints());

            int randomIndex = Random.Range(0, freePoints.Count);
            Transform result = freePoints[randomIndex];
            freePoints.RemoveAt(randomIndex);
            return result;
        }
    }
}