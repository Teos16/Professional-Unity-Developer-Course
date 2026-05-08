using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    public sealed class FireRaycastComponent : MonoBehaviour
    {
        [SerializeField] private float _distance = 100f;
        [SerializeField] private int _damage = 25;
        [SerializeField] private LayerMask _hitMask;
        [SerializeField] private Transform _firePoint;

        public void Fire()
        {
            if (!Physics.Raycast(
                    _firePoint.position, _firePoint.forward, out RaycastHit hit, _distance, _hitMask))
                return;

            HealthComponent healthComponent = hit.collider.GetComponentInParent<HealthComponent>();
            if (healthComponent != null) 
                healthComponent.TakeDamage(_damage);
        }
    }
}