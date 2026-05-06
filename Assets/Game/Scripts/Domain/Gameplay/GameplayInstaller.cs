using Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    //Don't modify
    [CreateAssetMenu(
        fileName = "GameplayInstaller",
        menuName = "Zenject/New Gameplay Installer"
    )]
    public sealed class GameplayInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private EntityCatalog _catalog;
        
        public override void InstallBindings()
        {
            Container.Bind<EntityWorld>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EntityCatalog>().FromInstance(_catalog).AsSingle();
        }
    }
}