using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class RotateInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
             entity.AddRotateRequest(new Request<Vector3>());
             entity.AddRotateCommand(new Command<RotateArgs>());
             entity.AddBehaviour<RotateBehaviour>();
        }
    }
}