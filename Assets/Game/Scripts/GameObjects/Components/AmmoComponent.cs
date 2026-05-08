using System;
using UnityEngine;

namespace SampleGame
{
    public class AmmoComponent : MonoBehaviour
    {
        public event Action OnEmpty;

        public bool IsEmpty => _ammo <= 0;

        public bool HasAmmo => _ammo > 0;

        [SerializeField]
        private int _maxAmmo;
        
        [SerializeField]
        private int _ammo;

        public void UseAmmo(int amount)
        {
            if (IsEmpty)
                return;

            _ammo = Mathf.Max(0, _ammo - amount);
            if (_ammo <= 0)
                this.OnEmpty?.Invoke();
        }

        public void AddAmmo(int amount)
        {
            _ammo = Mathf.Min(_maxAmmo, _ammo + amount);
        }
    }
}