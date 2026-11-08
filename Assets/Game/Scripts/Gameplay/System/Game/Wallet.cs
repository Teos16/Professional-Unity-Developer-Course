using System;
using Fusion;

namespace Game
{
    public sealed class Wallet : NetworkBehaviour
    {
        public event Action<int> OnGoldChanged;

        [Networked, OnChangedRender(nameof(InvokeGoldChanged))]
        public int Gold { get; private set; }

        public void Add(int amount)
        {
            if (HasStateAuthority && amount > 0)
                Gold += amount;
        }
        
        private void InvokeGoldChanged() => OnGoldChanged?.Invoke(Gold);
    }
}