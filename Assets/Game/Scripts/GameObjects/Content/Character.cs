using Game.Scripts.GameObjects.Components.Fire;
using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(MoveRequestComponent), typeof(HealthComponent))]
    [RequireComponent(typeof(MoveTransformComponent), typeof(RotateComponent), typeof(ArmorComponent))]
    public sealed class Character : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition,
        HealthComponent.IDamageHandler,
        IDualFireComponent
    {
        [SerializeField] private GameObject _leftWeapon;
        [SerializeField] private GameObject _rightWeapon;

        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveTransformComponent;
        private RotateComponent _rotateComponent;
        private HealthComponent _healthComponent;
        private ArmorComponent _armorComponent;

        private void OnEnable() => _healthComponent.OnHealthEmpty += OnHealthEmpty;

        private void OnDisable() => _healthComponent.OnHealthEmpty -= OnHealthEmpty;

        private void Awake()
        {
            _moveRequestComponent = this.GetComponent<MoveRequestComponent>();
            _moveTransformComponent = this.GetComponent<MoveTransformComponent>();
            _rotateComponent = this.GetComponent<RotateComponent>();
            _healthComponent = this.GetComponent<HealthComponent>();
            _armorComponent = this.GetComponent<ArmorComponent>();

            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);

            _healthComponent.SetDamageHandler(this);
        }

        private void OnHealthEmpty() => gameObject.SetActive(false);

        void IDualFireComponent.FireLeft()
        {
            if (_healthComponent.IsAlive())
                _leftWeapon.GetComponent<FireRequestComponent>().Fire();
        }

        void IDualFireComponent.FireRight()
        {
            if (_healthComponent.IsAlive())
                _rightWeapon.GetComponent<FireRequestComponent>().Fire();
        }

        void MoveRequestComponent.IAction.Invoke(Vector3 direction)
        {
            _moveTransformComponent.MoveStep(direction);
            _rotateComponent.RotateTowards(direction);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive();

        int HealthComponent.IDamageHandler.Handle(int damage) => _armorComponent.AbsorbDamage(damage);
    }
}