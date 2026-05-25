using UnityEngine;
using Zenject;

namespace SampleGame.Gameplay
{
    [CreateAssetMenu(
        fileName = "SaveFeatureInstaller",
        menuName = "Installers/SaveFeature"
    )]
    public sealed class SaveFeatureInstaller : ScriptableObjectInstaller
    {

        public override void InstallBindings()
        {
            InstallSaveComponents();
            InstallSerializers();
        }
        
        private void InstallSaveComponents()
        {
            Container.Bind<EntitySaveManager>().AsSingle();
            Container.Bind<EntityComponentsSerializer>().AsSingle();
            Container.Bind<EntityWorldSerializer>().AsSingle();
        }

        private void InstallSerializers()
        {
            Container.Bind<IComponentSerializer>()
                .To(x => x.AllNonAbstractClasses()
                    .DerivingFrom<IComponentSerializer>()
                    .FromAssemblyContaining<IComponentSerializer>())
                .FromNew()
                .AsCached();
        }
    }
}