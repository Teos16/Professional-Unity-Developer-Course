using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Common;

namespace SampleGame.Gameplay
{
    public struct EntityData
    {
        public int Id;
        public string Name;
        
        public SerializedVector3 Position;
        public SerializedVector3 Rotation;
        
        public Dictionary<string, object> Components;
    }
    
    public sealed class EntityWorldSerializer 
    {
        private readonly EntityWorld _world;
        private readonly EntityComponentsSerializer _componentsSerializer;

        public EntityWorldSerializer(EntityWorld world, EntityComponentsSerializer componentsSerializer)
        {
            _world = world;
            _componentsSerializer = componentsSerializer;
        }

        public EntityData[] Serialize()
        {
            IReadOnlyCollection<Entity> entities = _world.GetAll();
            
            EntityData[] result = new EntityData[entities.Count];

            int i = 0;
            foreach (Entity entity in entities)
            {
                result[i] = new EntityData
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Position = entity.transform.position,
                    Rotation = entity.transform.rotation,
                    Components = _componentsSerializer.Serialize(entity.gameObject)
                };
                i++;
            }

            return result;
        }

        public void Deserialize(EntityData[] dataSet)
        {
            _world.DestroyAll();

            foreach (EntityData data in dataSet) 
                _world.Spawn(data.Name, data.Position, data.Rotation, data.Id);
            
            SetEntityProperties(dataSet);
        }
        
        private void SetEntityProperties(EntityData[] dataSet)
        {
            foreach (EntityData data in dataSet)
            {
                if (_world.TryGet(data.Id, out Entity entity))
                {
                    entity.gameObject.name = data.Name;
                    entity.transform.position = data.Position;
                    entity.transform.rotation = data.Rotation;
                }
            
                if (data.Components is { Count: > 0 })
                    _componentsSerializer.Deserialize(entity.gameObject, data.Components);
            }
        }
    }
}