using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class GameCycleInstaller : IEntityInstaller<IGameContext>
    {
        [SerializeField]
        private ReactiveFloat _gameDuration = 20;
        
        public void Install(IGameContext context)
        {
            context.AddGameTime(_gameDuration);
            context.AddGameStartedEvent(new Event());
            context.AddGameFinishedEvent(new Event());
            context.AddBehaviour<GameCycleController>();    
        }
    }
}