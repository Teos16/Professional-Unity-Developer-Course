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
            
            entity.GetFireAction().Add(() =>
            {
                TeamType team = entity.GetOwner().Value.GetTeam().Value;
                gameContext.RaycastDamage(_firePoint.position, 
                                        _firePoint.forward, 
                                        _distance, 
                                        _hitMask, 
                                        _damage, 
                                        team);
            });
        }
    }
}