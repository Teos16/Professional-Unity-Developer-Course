using UnityEngine;

namespace Game.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionPrefab;
        
        private Bullet _bullet;

        private void Awake()
        {
            if (TryGetComponent(out Bullet bullet)) 
                _bullet = bullet;
        }
        
        private void OnEnable()
        {
            if(_bullet != null)
                _bullet.OnTriggerEntered += OnHit;
        }

        private void OnDisable()
        {
            if(_bullet != null)
                _bullet.OnTriggerEntered -= OnHit;
        }

        private void OnDestroy()
        {
            if(_bullet != null)
                _bullet.OnTriggerEntered -= OnHit;
        }

        private void OnHit() => Instantiate(_explosionPrefab, transform.position, _explosionPrefab.transform.rotation);
    }
}