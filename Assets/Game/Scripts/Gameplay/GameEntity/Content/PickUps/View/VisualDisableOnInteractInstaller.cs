using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class VisualDisableOnInteractInstaller : IGameEntityInstaller
    {
        [SerializeField] private GameObject _visual;
        
        public void Install(IGameEntity entity) => 
            entity.GetValue(GameEntityAPI.InteractCommand).Subscribe(_ => _visual.SetActive(false));
    }
}