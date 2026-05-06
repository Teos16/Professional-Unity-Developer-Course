using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Modules.Repositories
{
    public sealed class DebugLogRepository : IRepository
    {
        private readonly IRepository _origin;

        public DebugLogRepository(IRepository origin)
        {
            _origin = origin;
        }

        public async UniTask<bool> Save(JObject data, int version, CancellationToken ct = default)
        {
            bool success = await _origin.Save(data, version, ct);
            if (success)
            {
                Debug.Log($"<b><color=green>Saved version {version} with data :</color></b> {data}");
                return true;
            }
            
            Debug.Log($"<b><color=red>Save failed for version {version} with data :</color></b> {data}");
            return false;
        }

        public async UniTask<(bool, JObject)> Load(int version, CancellationToken ct = default)
        {
            (bool success, JObject data) = await _origin.Load(version, ct);
            if (!success)
            {
                Debug.Log($"<b><color=green>Loading of version {version} failed! Data :</color></b> {data}");
                return (false, data);
            }
            
            Debug.Log($"<b><color=green>Loaded version {version} with data :</color></b> {data}");
            return (true, data);
        }
    }
}