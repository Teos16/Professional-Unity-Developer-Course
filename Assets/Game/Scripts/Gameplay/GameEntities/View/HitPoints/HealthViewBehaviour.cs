using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class HealthViewBehaviour : IGameEntityInit, IGameEntityEnable, IGameEntityDisable
    {
        private readonly HealthView _view;
        private readonly TeamCatalog _teamConfig;

        private IReactiveValue<int> _health;
        private IValue<int> _maxHealth;
        private IValue<TeamType> _teamType;

        public HealthViewBehaviour(HealthView view, TeamCatalog teamConfig)
        {
            _view = view;
            _teamConfig = teamConfig;
        }

        public void Init(IGameEntity entity)
        {
            _health = entity.GetHealth();
            _maxHealth = entity.GetMaxHealth();
            _teamType = entity.GetTeam();
        }

        public void Enable(IGameEntity entity)
        {
            _health.OnEvent += this.OnHealthChanged;
            _view.Hide();
        }

        public void Disable(IGameEntity entity)
        {
            _health.OnEvent -= this.OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            int maxHealth = _maxHealth.Value;
            _view.SetColor(_teamConfig.GetTeam(_teamType.Value).Material.color);
            _view.SetProgress((float) health / maxHealth);
            _view.SetText($"{health}/{maxHealth}");
            _view.Show();
        }
    }
}