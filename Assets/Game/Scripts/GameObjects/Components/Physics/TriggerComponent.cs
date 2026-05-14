using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class TriggerComponent : MonoBehaviour
    {
        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;
        public event Action<IReadOnlyCollection<Collider2D>> OnTargetsChanged;

        private readonly HashSet<Collider2D> _currentColliders = new();

        private bool _isDirty;

        public IReadOnlyCollection<Collider2D> CurrentTargets => _currentColliders;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_currentColliders.Add(col))
            {
                OnEntered?.Invoke(col);
                _isDirty = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (_currentColliders.Remove(col))
            {
                OnExited?.Invoke(col);
                _isDirty = true;
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (_currentColliders.Contains(col))
                return;

            if (_currentColliders.Add(col))
            {
                OnEntered?.Invoke(col);
                _isDirty = true;
            }
        }

        private void Update()
        {
            if (_isDirty)
            {
                _isDirty = false;
                OnTargetsChanged?.Invoke(_currentColliders);
            }
        }
    }
}