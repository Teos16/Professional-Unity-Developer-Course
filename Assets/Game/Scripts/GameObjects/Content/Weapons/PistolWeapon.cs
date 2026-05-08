using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(FireBulletComponent),
        typeof(FireRequestComponent), 
        typeof(CooldownComponent))]
    [RequireComponent(typeof(AmmoComponent))]
    public sealed class PistolWeapon : MonoBehaviour
    {

        private FireBulletComponent _fireBulletComponent;
        private FireRequestComponent _fireRequestComponent;
        private CooldownComponent _cooldownComponent;
        private AmmoComponent _ammoComponent;
    
        private void Awake()
        {
            _fireBulletComponent = this.GetComponent<FireBulletComponent>();
            _fireRequestComponent = this.GetComponent<FireRequestComponent>();
            _cooldownComponent = this.GetComponent<CooldownComponent>();
            _ammoComponent = this.GetComponent<AmmoComponent>();
        
            _fireRequestComponent.SetCondition(
                () => _cooldownComponent.IsExpired && _ammoComponent.HasAmmo);
        
            _fireRequestComponent.SetAction(() =>
            {
                _fireBulletComponent.Fire();
                _ammoComponent.UseAmmo(1);
                _cooldownComponent.Reset();
            });
        }
    }
}