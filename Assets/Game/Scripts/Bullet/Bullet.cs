using System;
using Game.ShipRelated;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullet
{
    public class Bullet : MonoBehaviour
    {
        public TeamType Team { get; private set; } = TeamType.None;
        
        [SerializeField] private BulletConfig _config;
        
        private TransformBounds _levelBounds;
        
        private Vector2 _direction;

        private int _damage;
        private float _speed;
        
        public event Action OnTriggerEntered;
        public event Action<Bullet> OnDisabled; 

        private void Start()
        {
            Team = _config.TeamType;
            _damage = _config.BulletDamage;
            _speed = _config.BulletSpeed;
        }

        private void OnDisable() => OnDisabled?.Invoke(this);

        private void FixedUpdate()
        {
            Vector3 moveStep = _direction * (_speed * Time.fixedDeltaTime);
            transform.position += moveStep;

            if (!_levelBounds.InBounds(transform.position)) 
                gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEntered?.Invoke();
            other.GetComponent<Ship>().TakeDamage(_damage);
            gameObject.SetActive(false);
        }

        public void Initialize(Vector2 position, Vector2 direction, TransformBounds levelBounds)
        {
            _levelBounds ??= levelBounds;
            
            _direction = direction;

            transform.position = position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

            gameObject.SetActive(true);
        }
    }
}