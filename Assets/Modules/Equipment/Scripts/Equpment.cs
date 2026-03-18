using System;
using System.Collections.Generic;

namespace Modules.Equipments
{
    public sealed class Equipment<E, T> where E : Enum, IConvertible
    {
        public event Action<E, T> OnAdded;
        public event Action<E, T> OnRemoved;
        public event Action<E, T> OnChanged;

        public int Capacity => _slots.Length;
        public int Count => _count;

        private struct Slot
        {
            public T value;
            public bool occupied;
        }

        private readonly Slot[] _slots;
        private int _count;

        public Equipment(params KeyValuePair<E, T>[] items) : this()
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            for (int i = 0, count = items.Length; i < count; i++)
                this.Add(items[i]);
        }

        public Equipment()
        {
            var keys = (E[]) Enum.GetValues(typeof(E));
            int length = keys.Length;

            _slots = new Slot[length];
            for (int i = 0; i < length; i++)
                _slots[i] = new Slot();
        }

        public bool Add(KeyValuePair<E, T> item)
        {
            (E key, T value) = item;
            return this.Add(key, value);
        }

        public bool Add(E key, T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            ref Slot slot = ref this.GetSlot(key);
            if (slot.occupied)
                return false;

            slot.value = value;
            slot.occupied = true;
            _count++;
            
            this.OnAdded?.Invoke(key, value);
            return true;
        }

        public void Set(E key, T value)
        {
            
        }

        public bool Del(E key)
        {
            return true;
        }
        
        
        //
        // private bool SetInternal(ref Slot slot, T value)
        // {
        //     this.OnStateChanged?.Invoke();
        //     return true;
        // }

        private ref Slot GetSlot(E key)
        {
            var index = key.ToInt32(null);
            return ref _slots[index];
        }

        // public bool Put(T item)
        // {
        //     return !this.occupied && this.Set(item);
        // }
        //
        // private bool Set(T item)
        // {
        //     if (item == null)
        //         throw new ArgumentNullException(nameof(item));
        //

        // }
        //
        // public bool Clear()
        // {
        //     if (!this.occupied)
        //         return false;
        //
        //     this.value = default;
        //     this.occupied = false;
        //     this.OnStateChanged?.Invoke();
        //     return false;
        // }


        // public V GetItem(E type)
        // {
        //     if (type == null)
        //     {
        //         throw new ArgumentNullException()
        //     }
        //     
        //     if (_items.TryGetValue(type, out V item))
        //         return item;
        //
        //     throw new NullReferenceException($"Slot is empty {}");
        // }
        //
        // public bool TryGetItem(EquipmentType type, out Item result)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public void RemoveItem(EquipmentType type, Item item)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public void AddItem(EquipmentType type, Item item)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public void ChangeItem(EquipmentType type, Item item)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public bool HasItem(EquipmentType type)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public KeyValuePair<EquipmentType, Item>[] GetItems()
        // {
        //     throw new NotImplementedException();
        // }
    }
}