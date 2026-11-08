using Fusion;
using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class GoldPresenter : NetworkBehaviour
    {
        [SerializeField] private TMP_Text _view;

        private Wallet _wallet;

        public override void Spawned()
        {
            _wallet = GetBehaviour<Wallet>();
            _wallet.OnGoldChanged += this.OnGoldChanged;
            this.OnGoldChanged(_wallet.Gold);
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _wallet.OnGoldChanged -= this.OnGoldChanged;
        }

        private void OnGoldChanged(int gold) => _view.text = gold.ToString();
    }
}