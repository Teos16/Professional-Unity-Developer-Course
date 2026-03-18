using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Modules.Inventories
{
    public sealed class Inventory<T>
    {
        public interface IItemObserver
        {
            void OnCountChanged(int count);
        }

        public event Action<T, int> OnCountChanged;
        public event Action<T, int> OnCellAdded;
        public event Action<T> OnCellRemoved;

        [ShowInInspector]
        private readonly Dictionary<T, int> items = new();
        private readonly Dictionary<T, List<IItemObserver>> _itemObservers = new();

        public Inventory()
        {
        }

        public Inventory(IEnumerable<KeyValuePair<T, int>> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (KeyValuePair<T, int> item in items)
            {
                (T key, int value) = item;
                this.AddItems(key, value);
            }
        }

        public Inventory(params KeyValuePair<T, int>[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            for (int i = 0, length = items.Length; i < length; i++)
            {
                (T key, int value) = items[i];
                this.AddItems(key, value);
            }
        }

        [Button]
        public bool AddItems(T item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (this.items.TryGetValue(item, out int count))
            {
                count += range;
                this.items[item] = count;
                this.NotifyAboutCountChanged(item, count);
            }
            else
            {
                this.items.Add(item, range);
                this.OnCellAdded?.Invoke(item, range);
                this.NotifyAboutCountChanged(item, range);
            }

            return true;
        }

        [Button]
        public bool RemoveItem(T item)
        {
            return this.RemoveItems(item, 1);
        }

        [Button]
        public bool RemoveItems(T item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (!this.items.TryGetValue(item, out int count))
                return false;

            if (count < range)
                return false;

            count -= range;
            if (count > 0)
            {
                this.items[item] = count;
                this.NotifyAboutCountChanged(item, count);
            }
            else
            {
                this.items.Remove(item);
                this.NotifyAboutCountChanged(item, 0);
                this.OnCellRemoved?.Invoke(item);
            }

            return true;
        }

        public bool HasItem(T item)
        {
            return this.HasItems(item, 1);
        }

        public bool HasItems(T item, int count)
        {
            return item == null
                ? throw new ArgumentNullException(nameof(item))
                : this.items.TryGetValue(item, out int current) && current >= count;
        }

        public int GetCount(T item)
        {
            return item == null
                ? throw new ArgumentNullException(nameof(item))
                : this.items.TryGetValue(item, out int count)
                    ? count
                    : 0;
        }

        public IReadOnlyCollection<KeyValuePair<T, int>> GetItems()
        {
            return this.items;
        }

        public void Subscribe(T item, IItemObserver observer)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            if (!_itemObservers.TryGetValue(item, out List<IItemObserver> observers))
            {
                observers = new List<IItemObserver>();
                _itemObservers.Add(item, observers);
            }

            observers.Add(observer);
        }

        public void Unsubscribe(T item, IItemObserver observer)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            if (_itemObservers.TryGetValue(item, out List<IItemObserver> observers))
                observers.Remove(observer);
        }

        private void NotifyAboutCountChanged(T item, int count)
        {
            if (_itemObservers.TryGetValue(item, out List<IItemObserver> observers))
                for (int i = 0, length = observers.Count; i < length; i++)
                    observers[i].OnCountChanged(count);

            this.OnCountChanged?.Invoke(item, count);
        }
    }
}