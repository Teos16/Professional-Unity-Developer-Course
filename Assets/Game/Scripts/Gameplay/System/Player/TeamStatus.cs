using System.Linq;
using Fusion;

namespace Game
{
    public sealed class TeamStatus : NetworkBehaviour
    {
        public bool IsAnyCharacterDead()
        {
            foreach (PlayerRef player in Runner.ActivePlayers)
                if (TryGetCharacterHealth(player, out HealthComponent health) && health.IsDead)
                    return true;
            return false;
        }

        public bool AreAllCharactersAlive()
        {
            foreach (PlayerRef player in Runner.ActivePlayers)
                if (!TryGetCharacterHealth(player, out HealthComponent health) || health.IsDead)
                    return false;
            return true;
        }

        private bool TryGetCharacterHealth(PlayerRef player, out HealthComponent health)
        {
            health = null;
            if (!Runner.TryGetPlayerObject(player, out NetworkObject playerObject))
                return false;

            NetworkObject character = playerObject.GetBehaviour<Player>().Character;
            return character != null && character.TryGetBehaviour(out health);
        }
    }
}
