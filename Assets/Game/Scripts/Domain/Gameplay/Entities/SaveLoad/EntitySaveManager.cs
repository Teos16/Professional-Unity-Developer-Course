using Cysharp.Threading.Tasks;
using Modules.Repositories;
using Newtonsoft.Json.Linq;

namespace SampleGame.Gameplay
{
    public sealed class EntitySaveManager
    {
        private const string ENTITIES_KEY = "Entities";
        
        private readonly EntityWorldSerializer _worldSerializer;
        private readonly IRepository _gameRepository;
        private readonly IVersionProvider _versionProvider;
        
        public EntitySaveManager(EntityWorldSerializer worldSerializer, 
            IRepository gameRepository, 
            IVersionProvider versionProvider)
        {
            _worldSerializer = worldSerializer;
            _gameRepository = gameRepository;
            _versionProvider = versionProvider;
        }
        
        public async UniTask<(bool success, int version)> Save()
        {
            EntityData[] entityData = _worldSerializer.Serialize(); 

            JObject data = new() { { ENTITIES_KEY, JToken.FromObject(entityData) } };

            int version = _versionProvider.GetNextVersion();
            bool success = await _gameRepository.Save(data, version);
            return (success, version);
        }
        
        public async UniTask<bool> Load(string version)
        {
            if (int.TryParse(version, out int parsedVersion) && parsedVersion > 0)
            {
                (bool success, JObject gameData) = await _gameRepository.Load(parsedVersion);
                if (success && gameData.TryGetValue(ENTITIES_KEY, out JToken data))
                {
                    EntityData[] entityDataArray = data.ToObject<EntityData[]>();
                    _worldSerializer.Deserialize(entityDataArray);
                }

                return success;
            }
            return false;
        }
    }
}