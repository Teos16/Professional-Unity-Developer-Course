using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Inventories
{
    public class Inventory : IEnumerable<Item>
    {
        #region Events / Fields / Properties

        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        private readonly Item[,] _grid;
        private readonly Dictionary<Item, Vector2Int> _items;

        public int Width { get; }
        public int Height { get; }
        public int Count => GetItemCount();

        #endregion

        #region Constructors

        public Inventory(int width, int height)
        {
            if(width <= 0 || height <= 0 ) 
                throw new ArgumentException("Inventory dimensions must be positive.");
            
            Width = width;
            Height = height;
            
            _grid = new Item[Width, Height];
            _items = new Dictionary<Item, Vector2Int>();
        }

        public Inventory(int width, int height, IEnumerable<KeyValuePair<Item, Vector2Int>> items)
            : this(width, height)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (KeyValuePair<Item, Vector2Int> pair in items) 
                AddItem(pair.Key, pair.Value);
        }

        public Inventory(int width, int height, IEnumerable<Item> items)
            : this(width, height)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (Item item in items)
                AddItem(item);
        }

        public Inventory(int width, int height, params KeyValuePair<Item, Vector2Int>[] items)
            : this(width, height, (IEnumerable<KeyValuePair<Item, Vector2Int>>)items) { }

        public Inventory(int width, int height, params Item[] items)
            : this(width, height, (IEnumerable<Item>)items) { }
        
        #endregion

        #region AddItem / FindFreePosition / CanAddItem

        public bool CanAddItem(Item item, Vector2Int position) => CanAddItem(item, position.x, position.y);

        public bool CanAddItem(Item item)
        {
            if (!IsItemValidForAdding(item)) 
                return false;
            return FindFreePosition(item.Size, out _);
        }
        
        public bool FindFreePosition(Vector2Int size, out Vector2Int position) => 
            FindFreePosition(size.x, size.y, out position);

        public bool AddItem(Item item)
        {
            if (!IsItemValidForAdding(item)) return false;

            if (FindFreePosition(item.Size, out var position))
                return AddItem(item, position);

            return false;
        }

        public bool AddItem(Item item, Vector2Int position) => AddItem(item, position.x, position.y);

        public bool AddItem(Item item, int startX, int startY)
        {
            if (!CanAddItem(item, startX, startY)) return false;
            
            PlaceItem(item, startX, startY);
            OnAdded?.Invoke(item, new Vector2Int(startX, startY));
            return true;
        }

        #endregion

        #region RemoveItem / Clear

        public bool RemoveItem(Item item, out Vector2Int position)
        {
            if (item == null || !_items.TryGetValue(item, out position))
            {
                position = default;
                return false;
            }

            ClearCells(item);
            OnRemoved?.Invoke(item, position);
            return true;
        }
        
        public void Clear()
        {
            if (GetItemCount() == 0) return;
            Array.Clear(_grid, 0, _grid.Length);
            _items.Clear();
            OnCleared?.Invoke();
        }

        #endregion

        #region MoveItem

        public bool MoveItem(Item item, Vector2Int position)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (!_items.TryGetValue(item, out Vector2Int origin)) return false;

            ClearCells(item);

            if (!CanAddItem(item, position))
            {
                PlaceItem(item, origin.x, origin.y);
                return false;
            }

            PlaceItem(item, position.x, position.y);
            OnMoved?.Invoke(item, position);
            return true;
        }

        #endregion

        #region Contains / IsOccupied / IsFree

        public bool Contains(Item item)
        {
            if (item is null) return false;
            return _items.ContainsKey(item);
        }
        
        public bool IsOccupied(int x, int y) => _grid[x, y] != null;

        public bool IsFree(int x, int y) => !IsOccupied(x, y);

        #endregion

        #region GetItem / TryGetItem

        public Item GetItem(Vector2Int position) => _grid[position.x, position.y];
        
        public Item GetItem(int x, int y) => _grid[x, y];

        public bool TryGetItem(Vector2Int position, out Item item) =>
            TryGetItem(position.x, position.y, out item);

        public bool TryGetItem(int x, int y, out Item item)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                item = null;
                return false;
            }
            
            item = _grid[x, y];
            return item != null;
        }

        #endregion

        #region GetPositions / TryGetPositions

        public Vector2Int[] GetPositions(Item item)
        {
            if (item is null) throw new NullReferenceException(nameof(item));
            if (!Contains(item)) throw new KeyNotFoundException($"Item '{item}' is not in the inventory.");

            Vector2Int startPoint = _items[item];
            Vector2Int size = item.Size;
            Vector2Int[] positions = new Vector2Int[size.x * size.y];
    
            int i = 0;
            for (int x = startPoint.x; x < startPoint.x + size.x; x++)
                for (int y = startPoint.y; y < startPoint.y + size.y; y++)
                    positions[i++] = new Vector2Int(x, y);
    
            return positions;
        }

        public bool TryGetPositions(Item item, out Vector2Int[] positions)
        {
            if (item is null || !Contains(item))
            {
                positions = null;
                return false;
            }
            
            positions = GetPositions(item);
            return positions.Length > 0;
        }

        #endregion

        #region GetItemCount

        public int GetItemCount() => _items.Count;

        public int GetItemCount(string name)
        {
            int count = 0;
            foreach (Item item in _items.Keys)
                if (item.Name == name) 
                    count++;
            return count;
        }

        #endregion
        
        #region OptimizeSpace

        public void OptimizeSpace()
        {
            Dictionary<Item, Vector2Int>.KeyCollection keys = _items.Keys;
            int count = keys.Count;
            if (count == 0) return;

            Item[] rentedArray = ArrayPool<Item>.Shared.Rent(count);
            try
            {
                keys.CopyTo(rentedArray, 0);
                Array.Sort(rentedArray, 0, count, new ItemComparer());
                Clear();

                for (int i = 0; i < count; i++)
                {
                    Item item = rentedArray[i];
                    if (FindFreePosition(item.Size, out Vector2Int pos))
                        PlaceItem(item, pos.x, pos.y);
                    else
                        throw new InvalidOperationException(
                            $"Not enough space to place item {item} after optimization.");
                }
            }
            finally
            {
                ArrayPool<Item>.Shared.Return(rentedArray);
            }
        }

        #endregion
        
        #region IEnumerator

        public IEnumerator<Item> GetEnumerator()
        {
            Dictionary<Item, Vector2Int>.KeyCollection.Enumerator enumerator = _items.Keys.GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        
        #region CopyTo

        public void CopyTo(Item[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.GetLength(0) < Width || matrix.GetLength(1) < Height)
                throw new ArgumentException("Target matrix is smaller than inventory.", nameof(matrix));

            Array.Copy(_grid, matrix, _grid.Length);
        }

        #endregion

        #region Private methods
        
        private bool CanAddItem(Item item, int startX, int startY)
        {
            if (!IsItemValidForAdding(item)) return false;
            if (!AreCoordinatesNonNegative(startX, startY)) return false;

            int endX = startX + item.Size.x - 1;
            int endY = startY + item.Size.y - 1;
            if (!IsWithinBounds(endX, endY)) return false;

            return IsFreeSpace(startX, startY, endX, endY);
        }
        
        private bool IsItemValidForAdding(Item item)
        {
            if (item == null) return false;
            if (item.Size.x <= 0 || item.Size.y <= 0)
                throw new ArgumentException($"Item '{item}' has an invalid size", nameof(item));
            return !Contains(item);
        }
        
        private bool FindFreePosition(int sizeX, int sizeY, out Vector2Int position)
        {
            if (sizeX <= 0 || sizeY <= 0) 
                throw new ArgumentException("Item size must be positive.");
            
            for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
            {
                if (_grid[x, y] != null) continue;

                int endX = x + sizeX - 1;
                int endY = y + sizeY - 1;

                if (!IsWithinBounds(endX, endY)) continue;
                if (IsFreeSpace(x, y, endX, endY))
                {
                    position = new Vector2Int(x, y);
                    return true;
                }
            }

            position = default;
            return false;
        }

        private bool AreCoordinatesNonNegative(int x, int y) => x >= 0 && y >= 0;
        
        private bool IsWithinBounds(int endX, int endY) => endX < Width && endY < Height;

        private bool IsFreeSpace(int startX, int startY, int endX, int endY)
        {
            for (int x = startX; x <= endX; x++)
                for (int y = startY; y <= endY; y++)
                    if (_grid[x, y] != null)
                        return false;

            return true;
        }

        private void PlaceItem(Item item, int startX, int startY)
        {
            for (int x = startX; x < startX + item.Size.x; x++)
                for (int y = startY; y < startY + item.Size.y; y++)
                    _grid[x, y] = item;
            
            _items.Add(item, new Vector2Int(startX, startY));
        }

        private void ClearCells(Item item)
        {
            Vector2Int startPoint = _items[item];
            
            for (int x = startPoint.x; x < startPoint.x + item.Size.x; x++)
                for (int y = startPoint.y; y < startPoint.y + item.Size.y; y++)
                    _grid[x, y] = null;
            
            _items.Remove(item);
        }

        private class ItemComparer : IComparer<Item>
        {
            public int Compare(Item a, Item b)
            {
                if (a == null && b == null) return 0;
                if (a == null) return -1;
                if (b == null) return 1;

                // Area comparison
                int areaComparison = GetArea(b).CompareTo(GetArea(a));
                if (areaComparison != 0)
                    return areaComparison;
                
                // ID comparison
                return a.Id.CompareTo(b.Id);
            }

            private int GetArea(Item item) => item.Size.x * item.Size.y;
        }
        
        #endregion
    }
}