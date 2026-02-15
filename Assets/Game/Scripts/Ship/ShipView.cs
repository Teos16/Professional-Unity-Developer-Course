using DG.Tweening;
using UnityEngine;

namespace Game.ShipRelated
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

        private AudioSource _audioSource;
        private Material _material;
        private Tweener _damageAnimation;
        
        private ParticleSystem _destroyEffectPrefab;
        private AudioClip _fireSFX;
        private AudioClip _damageSFX;

        private AnimationCurve _hitAnimationCurve;
        private float _moveSpeed;
        private float _hitDuration;
        private string _hitPropertyName;
        private float _moveRotationAngle;

        private void Start()
        {
            _material = new Material(_viewConfig.MaterialPrefab);
            _renderer.material = _material;
            
            _audioSource = GetComponent<AudioSource>();

            _destroyEffectPrefab = _viewConfig.DestroyEffectPrefab;
            _fireSFX = _viewConfig.FireSFX;
            _damageSFX = _viewConfig.DamageSFX;
            
            _hitDuration = _viewConfig.HitDuration; 
            _hitPropertyName = _viewConfig.HitPropertyName;
            _moveRotationAngle = _viewConfig.MoveRotationAngle;
            _hitAnimationCurve = _viewConfig.HitAnimationCurve;
            
            OnShipInitialized();
            _ship.OnInitialized += OnShipInitialized;
        }

        private void OnShipInitialized()
        {
            _moveSpeed = _ship.MoveSpeed;
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
            if (_fireSFX)
                _audioSource.PlayOneShot(_fireSFX);
            if (_fireVFX)
                _fireVFX.Play();
        }

        private void OnDeath()
        {
            ParticleSystem prefab = _destroyEffectPrefab;
            Instantiate(prefab, _viewTransform.position, prefab.transform.rotation);
        }
        
        private void AnimateDamage()
        {
            if (_damageAnimation.IsActive())
                _damageAnimation.Kill();

            _damageAnimation = DOVirtual.Float(
                NORMALIZED_ANIMATION_START,
                NORMALIZED_ANIMATION_END,
                _hitDuration,
                progress => _material?.SetFloat(
                    _hitPropertyName, _hitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);

            if (_damageSFX)
                _audioSource.PlayOneShot(_damageSFX);
        }
        
        private void AnimateMovement(float deltaTime)
        {
            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = _moveRotationAngle * _ship.MoveDirection.y;
            shipAngles.y = _moveRotationAngle * YAW_SCALE * _ship.MoveDirection.x * YAW_DIRECTION;
            
            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = _moveSpeed * deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }
    }
}