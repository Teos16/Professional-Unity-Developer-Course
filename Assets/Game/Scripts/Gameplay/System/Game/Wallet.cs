using System;
using Fusion;
using Sirenix.OdinInspector;

namespace Game
{
    public sealed class Wallet : NetworkBehaviour
    {
        public event Action<int> OnGoldChanged;

        [Networked, OnChangedRender(nameof(InvokeGoldChanged))]
        public int Gold { get; private set; }

        [Button]
        public void Add(int amount)
        {
            if (HasStateAuthority && amount > 0)
                Gold += amount;
        }
        
        public bool TrySpend(int amount)
        {
            if (!HasStateAuthority || Gold < amount)
                return false;
            Gold -= amount;
            return true;
        }
        
        private void InvokeGoldChanged() => OnGoldChanged?.Invoke(Gold);
    }
}