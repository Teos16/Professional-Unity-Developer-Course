using System;

namespace Game
{
    public sealed class GameCycle
    {
        public event Action OnDeath;
        public event Action OnVictory;
        
        public void Lose() => OnDeath?.Invoke();
        public void Win() => OnVictory?.Invoke();
    }
}