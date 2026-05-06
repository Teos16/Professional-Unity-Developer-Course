using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Modules.Repositories
{
    public interface IRepository
    {
        UniTask<bool> Save(JObject data, int version, CancellationToken ct = default);

        UniTask<(bool, JObject)> Load(int version, CancellationToken ct = default);
    }
}