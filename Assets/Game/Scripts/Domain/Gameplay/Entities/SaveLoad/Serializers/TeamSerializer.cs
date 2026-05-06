using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class TeamSerializer : IComponentSerializer<TeamType>
    {
        public string Key => "Team";

        public bool TrySerialize(GameObject go, out TeamType data)
        {
            if (go.TryGetComponent(out Team team))
            {
                data = team.Type;
                return true;
            }
            
            data = default;
            return false;
        }

        public void Deserialize(GameObject go, TeamType data)
        {
            if (go.TryGetComponent(out Team team)) 
                team.Type = data;
        }
    }
}