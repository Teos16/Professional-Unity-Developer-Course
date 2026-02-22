using DG.Tweening;
using UnityEngine;

namespace Game.Ships
{
    [RequireComponent(typeof(Ship))]
    public sealed class ShipView : MonoBehaviour
    {
        private const float NORMALIZED_ANIMATION_START = 0f;
        private const float NORMALIZED_ANIMATION_END = 1f;
        
        private const float YAW_SCALE = 0.5f;       // half of pitch for a nicer feel
        private const float YAW_DIRECTION = -1f;    // invert yaw to match input/visual orientation

        [Header("Ship")]
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipControllerViewConfig _viewConfig;

        [Header("Visual")] 
        [SerializeField] private ParticleSystem _fireVFX;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private AudioSource _audioSource;
        
        private Material _material;
        private Tweener _damageAnimation;
        
        private void Start()
        {
            _material = new Material(_viewConfig.MaterialPrefab);
            _renderer.material = _material;
        }

        private void OnEnable()
        {
            _ship.OnHealthChanged += OnHealthChanged;
            _ship.OnDeath += OnDeath;
            _ship.OnFired += OnFire;
        }

        private void OnDisable()
        {
            _ship.OnHealthChanged -= OnHealthChanged;
            _ship.OnDeath -= OnDeath;
            _ship.OnFired -= OnFire;
        }
        
        private void LateUpdate() => AnimateMovement(Time.deltaTime);

        private void OnHealthChanged(int health, int _)
        {
            if(health > 0)
                AnimateDamage();
        }

        private void OnFire()
        {
            if (_viewConfig.FireSFX)
                _audioSource.PlayOneShot(_viewConfig.FireSFX);
            if (_fireVFX)
                _fireVFX.Play();
        }

        private void OnDeath(GameObject _)
        {
            ParticleSystem prefab = _viewConfig.DestroyEffectPrefab;
            Instantiate(prefab, _viewTransform.position, prefab.transform.rotation);
        }
        
        private void AnimateDamage()
        {
            if (_damageAnimation.IsActive())
                _damageAnimation.Kill();

            _damageAnimation = DOVirtual.Float(
                NORMALIZED_ANIMATION_START,
                NORMALIZED_ANIMATION_END,
                _viewConfig.HitDuration,
                progress => _material?.SetFloat(
                    _viewConfig.HitPropertyName, _viewConfig.HitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);

            if (_viewConfig.DamageSFX)
                _audioSource.PlayOneShot(_viewConfig.DamageSFX);
        }
        
        private void AnimateMovement(float deltaTime)
        {
            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = _viewConfig.MoveRotationAngle * _ship.MoveDirection.y;
            shipAngles.y = _viewConfig.MoveRotationAngle * YAW_SCALE * _ship.MoveDirection.x * YAW_DIRECTION;
            
            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = _viewConfig.MoveSpeed * deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }
    }
}