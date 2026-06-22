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
            Container.Bind<IComponentSerializer>().To<CountdownSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<DestinationPointSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<HealthSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<ProductionOrderSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<ResourceBagSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<TargetObjectSerializer>().AsCached();
            Container.Bind<IComponentSerializer>().To<TeamSerializer>().AsCached();
        }
    }
}