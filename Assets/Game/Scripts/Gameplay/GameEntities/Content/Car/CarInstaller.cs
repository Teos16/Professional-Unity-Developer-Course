using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CarInstaller : GameEntityInstaller
    {
        [SerializeField]
        private CarController _carController;

        [SerializeField]
        private TransformInstaller _transformInstaller;

        [SerializeField]
        private MoveInstaller _moveInstaller;

        [SerializeField]
        private HealthInstaller _healthInstaller;

        [SerializeField]
        private TakeDamageInstaller _takeDamageInstaller;

        [SerializeField]
        private InteractibleInstaller _interactibleInstaller;

        [SerializeField]
        private Transform _exitPoint;

        [SerializeField]
        private ReactiveVariable<TeamType> _team = TeamType.NEUTRAL;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            _transformInstaller.Install(entity);
            entity.AddTransform(this.transform);
            entity.AddExitPoint(_exitPoint);
            entity.AddTeam(_team);

            this.InstallMove(entity);

            _healthInstaller.Install(entity);
            _takeDamageInstaller.Install(entity);
            
            entity.GetTakeDamageCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(damage => entity.ReduceHealth(damage));
            
            entity.GetHealth()
                .Subscribe(health => this.gameObject.SetActive(health > 0))
                .AddTo(_disposables);

            _interactibleInstaller.Install(entity);
            entity.GetInteractCommand()
                .AddCondition(target => target.HasCharacterTag())
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(character => character.EnterTransport(entity));
            
            entity.AddActivateAction(new InlineAction(() => _carController.StartCar()));
            entity.AddDeactivateAction(new InlineAction(() => _carController.StopCar()));
        }

        private void InstallMove(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddCondition(_ => _carController.CarStarted)
                .AddAction(args =>
                {
                    _carController.ApplyTurn(args.direction.x);
                    _carController.ApplyForce(args.direction.z);
                });
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}