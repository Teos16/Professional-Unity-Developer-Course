using System;
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
            if (item == null || !Contains(item))
            {
                position = default;
                return false;
            }

            position = FindItemStartPoint(item);
            ClearCells(item);
            OnRemoved?.Invoke(item, position);
            return true;
        }
        
        public void Clear()
        {
            if (GetItemCount() == 0) return;
            Array.Clear(_grid, 0, _grid.Length);
            OnCleared?.Invoke();
        }

        #endregion

        #region MoveItem

        public bool MoveItem(Item item, Vector2Int position)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (!Contains(item)) return false;

            var origin = FindItemStartPoint(item);
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
            
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                if (Equals(_grid[x, y], item))
                    return true;

            return false;
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
            
            List<Vector2Int> positions = new();
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                if (Equals(_grid[x, y], item))
                    positions.Add(new Vector2Int(x, y));

            return positions.ToArray();
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

        public int GetItemCount() => GetItemCount(item => true);
        
        public int GetItemCount(string name) => GetItemCount(item => item.Name == name);

        #endregion
        
        #region OptimizeSpace

        public void OptimizeSpace()
        {
            HashSet<Item> seen = new();
            List<Item> items = new();
            
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                Item item = _grid[x, y];
                if (item != null && seen.Add(item))
                    items.Add(item);
            }

            Array.Clear(_grid, 0, _grid.Length);

            List<Item> sorted = new List<Item>(items);
            sorted.Sort(CompareItems);

            foreach (var item in sorted)
                if (FindFreePosition(item.Size, out var pos))
                    PlaceItem(item, pos.x, pos.y);
        }

        #endregion
        
        #region IEnumerator

        public IEnumerator<Item> GetEnumerator()
        {
            HashSet<Item> uniqueItems = new();
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                var item = _grid[x, y];
                if (item != null && uniqueItems.Add(item))
                    yield return item;
            }
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
        
        private int GetItemCount(Func<Item, bool> condition)
        {
            var items = new HashSet<Item>();
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                var item = _grid[x, y];
                if (item != null && condition(item))
                    items.Add(item);
            }
            return items.Count;
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

        private Vector2Int FindItemStartPoint(Item item)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (Equals(_grid[x, y], item))
                    {
                        if (x < minX) minX = x;
                        if (y < minY) minY = y;
                    }

            return minX == int.MaxValue ? default : new Vector2Int(minX, minY);
        }

        private void PlaceItem(Item item, int startX, int startY)
        {
            for (int x = startX; x < startX + item.Size.x; x++)
                for (int y = startY; y < startY + item.Size.y; y++)
                    _grid[x, y] = item;
        }

        private void ClearCells(Item item)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (Equals(_grid[x, y], item))
                        _grid[x, y] = null;
        }

        private int CompareItems(Item a, Item b)
        {
            // Area comparison
            int areaComparison = CompareByAreaDesc(a, b);
            if (areaComparison != 0)
                return areaComparison;

            // ID comparison
            return CompareByIdAsc(a, b);
        }

        private int CompareByAreaDesc(Item a, Item b) => GetArea(b).CompareTo(GetArea(a));
        
        private int GetArea(Item item) => item.Size.x * item.Size.y;

        private int CompareByIdAsc(Item a, Item b) => a.Id.CompareTo(b.Id);
        
        #endregion
    }
}