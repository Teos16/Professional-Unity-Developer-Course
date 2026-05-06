using Cysharp.Threading.Tasks;
using Modules.Repositories;
using Newtonsoft.Json.Linq;

namespace SampleGame.Gameplay
{
    public sealed class EntitySaveManager
    {
        private const string ENTITIES_KEY = "Entities";
        
        private readonly EntitySerializer _serializer;
        private readonly IRepository _gameRepository;
        private readonly IVersionProvider _versionProvider;
        
        public EntitySaveManager(EntitySerializer serializer, 
            IRepository gameRepository, 
            IVersionProvider versionProvider)
        {
            _serializer = serializer;
            _gameRepository = gameRepository;
            _versionProvider = versionProvider;
        }
        
        public async UniTask<(bool success, int version)> Save()
        {
            EntityData[] entityData = _serializer.Serialize(); 

            JObject gameData = await UniTask.RunOnThreadPool(() =>
            {
                JObject data = new();
                data.Add(ENTITIES_KEY, JToken.FromObject(entityData));
                return data;
            });

            int version = _versionProvider.GetNextVersion();
            bool success = await _gameRepository.Save(gameData, version);
            return (success, version);
        }
        
        public async UniTask<bool> Load(string version)
        {
            if (int.TryParse(version, out int parsedVersion) && parsedVersion > 0)
            {
                (bool success, JObject gameData) = await _gameRepository.Load(parsedVersion);
                if (success && gameData.TryGetValue(ENTITIES_KEY, out JToken data))
                {
                    EntityData[] entityDataArray = await UniTask.RunOnThreadPool(
                        () => data.ToObject<EntityData[]>());
                    _serializer.Deserialize(entityDataArray);
                }

                return success;
            }
            return false;
        }
    }
}