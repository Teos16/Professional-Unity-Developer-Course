using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class MoveInstaller : IGameEntityInstaller
    {
        [SerializeField] private Cooldown _moveTime = new(0.04f, 0);
        
        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.MoveRequest, new Request<Vector3>());
            Command<MoveArgs> moveCommand = new Command<MoveArgs>();
            moveCommand.AddAction(_ => _moveTime.ResetTime());
            
            entity.AddValue(GameEntityAPI.MoveCommand, moveCommand);
            
            entity.AddValue(GameEntityAPI.MoveTime, _moveTime);
            entity.WhenFixedTick(_moveTime.Tick);
            
            entity.AddBehaviour(new MoveBehaviour());
        }
    }
}