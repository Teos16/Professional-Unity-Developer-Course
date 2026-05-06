using System.Collections.Generic;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class ProductionOrderSerializer : IComponentSerializer<List<string>>
    {
        public string Key => "ProductionOrder";

        private readonly EntityCatalog _catalog;

        public ProductionOrderSerializer(EntityCatalog catalog) => _catalog = catalog;

        public bool TrySerialize(GameObject go, out List<string> data)
        {
            
            if (go.TryGetComponent(out ProductionOrder productionOrder))
            {
                List<string> result = new List<string>();

                foreach (EntityConfig config in productionOrder.Queue)
                    result.Add(config.Name);

                data = result;
                return true;
            }

            data = null;
            return false;
        }

        public void Deserialize(GameObject go, List<string> data)
        {
            if (go.TryGetComponent(out ProductionOrder productionOrder))
            {
                List<EntityConfig> order = new();

                foreach (string entityName in data)
                {
                    if (_catalog.FindConfig(entityName, out EntityConfig config))
                        order.Add(config);
                }

                productionOrder.Queue = order;
            }
        }
    }
}