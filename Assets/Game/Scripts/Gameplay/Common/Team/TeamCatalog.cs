using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "TeamCatalog",
        menuName = "Game/New TeamCatalog"
    )]
    public sealed class TeamCatalog : ScriptableObject, IEnumerable<TeamConfig>
    {
        [SerializeField]
        private List<TeamConfig> _teams;
        
        public bool TryGetTeam(TeamType teamType, out TeamConfig config)
        {
            for (int i = 0, count = _teams.Count; i < count; i++)
            {
                config = _teams[i];
                if (config.Team == teamType)
                    return true;
            }

            config = null;
            return false;
        }
        

        public TeamConfig GetTeam(TeamType teamType)
        {
            for (int i = 0, count = _teams.Count; i < count; i++)
            {
                TeamConfig config = _teams[i];
                if (config.Team == teamType)
                    return config;
            }

            throw new KeyNotFoundException($"Team of type {teamType} is not found!");
        }

        public IEnumerator<TeamConfig> GetEnumerator()
        {
            return _teams.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}