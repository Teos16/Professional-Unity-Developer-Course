using Fusion;

namespace Game
{
    public sealed class GameState : NetworkBehaviour
    {
        [Networked] public GameStatus Status { get; set; } = GameStatus.Waiting;
    }
}