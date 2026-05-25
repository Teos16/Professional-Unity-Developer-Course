using Modules.Encryption;
using Modules.Hashing;
using Modules.Repositories;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Domain
{
    [CreateAssetMenu(
        fileName = "ApplicationInstaller",
        menuName = "Installers/Repository"
    )]
    public sealed class RepositoryInstaller : ScriptableObjectInstaller
    {
        private const string EncryptionKey = "my-secret-encryption-key";
        private const string HmacKey = "my-secret-hmac-key";
        
        [SerializeField] private string _uri = "http://127.0.0.1:8888";
        [SerializeField] private string _fileName = "SaveData.txt";
        
        public override void InstallBindings() => InstallRepositories();

        private void InstallRepositories()
        {
            Container
                .Bind<IEncryptor>()
                .To<AesEncryptor>()
                .AsSingle()
                .WithArguments(EncryptionKey);

            Container
                .Bind<IHashProvider>()
                .To<HmacSha256Provider>()
                .FromMethod(_ => new HmacSha256Provider(HmacKey))
                .AsSingle();
            
            Container.Bind<RemoteRepository>()
                .AsCached()
                .WithArguments(_uri);
        
            Container.Bind<FileRepository>()
                .AsCached()
                .WithArguments(_fileName);
            
            Container
                .Bind<IRepository>()
                .To<SyncRepository>()
                .FromMethod(CreateSyncRepository)
                .AsSingle();
            
            Container
                .Decorate<IRepository>()
                .With<BackgroundThreadRepository>();
            
            Container
                .Bind<IVersionProvider>()
                .To<LastVersionStorage>()
                .AsSingle();
        }
        
        private SyncRepository CreateSyncRepository(InjectContext ctx) => new(
            ctx.Container.Resolve<FileRepository>(),
            ctx.Container.Resolve<RemoteRepository>()
        );
    }
}