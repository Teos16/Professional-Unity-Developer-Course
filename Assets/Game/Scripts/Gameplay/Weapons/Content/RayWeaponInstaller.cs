using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class RayWeaponInstaller : WeaponInstaller
    {
        [SerializeField]
        private float _distance = 100f;

        [SerializeField]
        private int _damage = 25;

        [SerializeField]
        private LayerMask _hitMask;

        [SerializeField]
        private Transform _firePoint;

        public override void Install(IWeaponEntity entity)
        {
            base.Install(entity);

            GameContext gameContext = GameContext.Instance;
            entity.GetFireCommand().AddAction(() =>
            {
                IGameEntity owner = entity.GetOwner().Value;
                TeamType team = owner.GetTeam().Value;
                
                IExpression<float> multiplier = owner.GetDamageMultiplier();
                int damage = Mathf.RoundToInt(_damage * multiplier.Value);
                Debug.Log($"NEW DAMAGE {damage} with mul {multiplier.Value}");
                
                if (Physics.Raycast(_firePoint.position, _firePoint.forward, out RaycastHit hit, _distance, _hitMask) &&
                    hit.collider.TryGetComponent(out IGameEntity target))
                    gameContext.TakeDamage(target, _damage, team);
            });
        }
    }
}