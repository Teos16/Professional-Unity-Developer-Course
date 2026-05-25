using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Modules.Repositories
{
    public sealed class BackgroundThreadRepository : IRepository
    {
        private readonly IRepository _repository;
        
        public BackgroundThreadRepository(IRepository repository) => _repository = repository;

        public async UniTask<bool> Save(JObject data, int version, CancellationToken ct = default) => 
            await UniTask.RunOnThreadPool(() => _repository.Save(data, version, ct), cancellationToken: ct);

        public async UniTask<(bool, JObject)> Load(int version, CancellationToken ct = default) => 
            await UniTask.RunOnThreadPool(() => _repository.Load(version, ct), cancellationToken: ct);
    }
}