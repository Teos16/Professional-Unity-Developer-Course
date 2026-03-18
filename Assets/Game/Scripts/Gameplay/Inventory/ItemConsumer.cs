using System;
using System.Collections.Generic;
using Modules.Inventories;
using Sirenix.OdinInspector;

namespace SampleGame.Gameplay
{
    public sealed class ItemConsumer
    {
        public event Action<Item> OnItemConsumed;

        private readonly Inventory<Item> inventory;
        private readonly Dictionary<Item, IHandler> _handlers = new();

        public ItemConsumer(Inventory<Item> inventory) => 
            this.inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));

        [Button]
        public bool CanConsume(Item item) => 
            item != null && item.IsConsumable && this.inventory.HasItem(item);

        [Button]
        public bool Consume(Item item)
        {
            if (!this.CanConsume(item))
                return false;
            
            this.inventory.RemoveItem(item);
            
            if (_handlers.TryGetValue(item, out IHandler handler)) 
                handler.ProcessConsume(item);
            
            this.OnItemConsumed?.Invoke(item);
            return true;
        }

        public void AddHandler(Item item, IHandler handler)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _handlers.Add(item, handler);
        }
        
        public void RemoveHandler(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            
            _handlers.Remove(item);
        }
        
        public interface IHandler
        {
            void ProcessConsume(Item item);
        }
    }
}