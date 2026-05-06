using Modules.Encryption;
using Modules.Hashing;
using Modules.Repositories;
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
        private const string EncryptionKey = "my-secret-encryption-key";
        private const string HmacKey = "my-secret-hmac-key";
        
        [SerializeField] private string _uri = "http://127.0.0.1:8888";
        [SerializeField] private string _fileName = "SaveData.txt";

        public override void InstallBindings()
        {
            InstallEntitySaveComponents();
            InstallEntitySerializers();
            InstallRepositories();
        }

        private void InstallEntitySaveComponents()
        {
            Container.Bind<EntitySaveManager>().AsSingle();
            Container.Bind<EntityComponentsSerializer>().AsSingle();
            Container.Bind<EntitySerializer>().AsSingle();
        }

        private void InstallEntitySerializers()
        {
            Container.Bind<IComponentSerializer>()
                .To(x => x.AllNonAbstractClasses()
                    .DerivingFrom<IComponentSerializer>()
                    .FromAssemblyContaining<IComponentSerializer>())
                .FromNew()
                .AsCached();
        }

        private void InstallRepositories()
        {
            Container.Bind<RemoteRepository>()
                .AsCached()
                .WithArguments(_uri);
        
            Container.Bind<FileRepository>()
                .AsCached()
                .WithArguments(_fileName);
            
            Container
                .Bind<IEncryptor>()
                .To<AesEncryptor>()
                .WithArguments(EncryptionKey)
                .WhenInjectedInto<RemoteRepository>();

            Container
                .Bind<IHashProvider>()
                .FromInstance(new HmacSha256Provider(HmacKey))
                .WhenInjectedInto<RemoteRepository>();

            Container
                .Bind<IEncryptor>()
                .To<AesEncryptor>()
                .WithArguments(EncryptionKey)
                .WhenInjectedInto<FileRepository>();

            Container
                .Bind<IHashProvider>()
                .FromInstance(new HmacSha256Provider(HmacKey))
                .WhenInjectedInto<FileRepository>();
            
            Container
                .Bind<IRepository>()
                .To<SyncRepository>()
                .FromMethod(this.CreateSyncRepository)
                .AsSingle();
            
            Container.Bind<IVersionProvider>()
                .To<LastVersionStorage>()
                .AsSingle();
        }
        
        private SyncRepository CreateSyncRepository(InjectContext ctx) => new(
            ctx.Container.Resolve<FileRepository>(),
            ctx.Container.Resolve<RemoteRepository>()
        );
    }
}