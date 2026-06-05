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

            _moveInstaller.Install(entity);
            entity.GetMoveCondition().Add(_ => entity.DoesHealthExist());
            entity.GetMoveCondition().Add(_ => _carController.CarStarted);
            entity.GetMoveAction().Add((direction, _) =>
            {
                _carController.ApplyTurn(direction.x);
                _carController.ApplyForce(direction.z);
            });
            
            _healthInstaller.Install(entity);
            _takeDamageInstaller.Install(entity);
            entity.GetTakeDamageAction().Add(damage => entity.ReduceHealth(damage));
            entity.GetHealth().Subscribe(health => this.gameObject.SetActive(health > 0)).AddTo(_disposables);

            _interactibleInstaller.Install(entity);
            entity.GetInteractCondition().Add(target => target.HasCharacterTag());
            entity.GetInteractAction().Add(character => character.EnterTransport(entity));
            
            entity.AddActivateAction(new InlineAction(() => _carController.StartCar()));
            entity.AddDeactivateAction(new InlineAction(() =>  _carController.StopCar()));
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}