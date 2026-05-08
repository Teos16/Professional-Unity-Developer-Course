using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(FireRaycastComponent),
                        typeof(FireRequestComponent), 
                        typeof(CooldownComponent))]
    [RequireComponent(typeof(AmmoComponent))]
    public sealed class RifleWeapon : MonoBehaviour
    {
        private FireRaycastComponent _fireRaycastComponent;
        private FireRequestComponent _fireRequestComponent;
        private CooldownComponent _cooldownComponent;
        private AmmoComponent _ammoComponent;
        
        private void Awake()
        {
            _fireRaycastComponent = this.GetComponent<FireRaycastComponent>();
            _fireRequestComponent = this.GetComponent<FireRequestComponent>();
            _cooldownComponent = this.GetComponent<CooldownComponent>();
            _ammoComponent = this.GetComponent<AmmoComponent>();
            
            _fireRequestComponent.SetCondition(
                () => _cooldownComponent.IsExpired && _ammoComponent.HasAmmo);
            
            _fireRequestComponent.SetAction(() =>
            {
                _fireRaycastComponent.Fire();
                _ammoComponent.UseAmmo(1);
                _cooldownComponent.Reset();
            });
        }
    }
}