using Fusion;

namespace Game
{
    public sealed class Wallet : NetworkBehaviour
    {
        [Networked] public int Gold { get; private set; }

        public void Add(int amount)
        {
            if (HasStateAuthority && amount > 0)
                Gold += amount;
        }
    }
}