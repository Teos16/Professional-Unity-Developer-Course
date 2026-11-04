using Fusion;

namespace Game
{
    public sealed class GameCycle : NetworkBehaviour
    {
        [Networked] public GameStatus State { get; private set; } = GameStatus.Waiting;

        public void StartGame()
        {
            if (HasStateAuthority && State == GameStatus.Waiting) 
                State = GameStatus.Playing;
        }

        public void Win()
        {
            if (HasStateAuthority && State == GameStatus.Playing) 
                State = GameStatus.Won;
        }
        
        public void Lose()      
        {
            if (HasStateAuthority && State == GameStatus.Playing) 
                State = GameStatus.Lost;
        }
    }
}