using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class HealthBarPresenter : NetworkBehaviour
    {
        [SerializeField] private SmoothHealthBar _view;

        private HealthComponent _health;

        public override void Spawned()
        {
            _health = GetBehaviour<HealthComponent>();
            _health.OnHealthChanged += this.OnHealthChanged;
            this.UpdateView(smooth: false);
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _health.OnHealthChanged -= this.OnHealthChanged;
        }

        private void OnHealthChanged(int _) => this.UpdateView(smooth: true);

        private void UpdateView(bool smooth)
        {
            _view.Set((float) _health.Current / _health.Max, smooth);
            _view.SetCaption($"{_health.Current}/{_health.Max}");
        }
    }
}