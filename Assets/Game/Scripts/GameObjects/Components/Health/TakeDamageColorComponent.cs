using DG.Tweening;
using UnityEngine;

namespace Game
{
    public sealed class TakeDamageColorComponent : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] _renderers;

        [SerializeField]
        private Color _damagedColor = Color.red;

        [SerializeField]
        private float _frequency = 0.2f;

        [SerializeField]
        private int _loops = 3;
        
        private Color _baseColor;

        private float _blend; // 0..1
        private Tween _tween;
        
        private HealthComponent _healthComponent;

        private void Reset()
        {
            _renderers = GetComponentsInChildren<SpriteRenderer>();
        }

        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
            _baseColor = _renderers is {Length: > 0} ? _renderers[0].color : Color.white;
        }

        private void OnEnable() => _healthComponent.OnHealthChanged += TakeDamage;

        private void OnDisable()
        {
            _healthComponent.OnHealthChanged -= TakeDamage;
            _tween?.Kill();
        }

        private void TakeDamage(float _)
        {
            _tween?.Kill();

            _tween = DOTween.Sequence()
                .Append(DOTween.To(() => _blend, x => _blend = x, 1f, _frequency))
                .Append(DOTween.To(() => _blend, x => _blend = x, 0f, _frequency))
                .SetLoops(_loops, LoopType.Restart);
        }

        private void LateUpdate()
        {
            Color color = Color.Lerp(_baseColor, _damagedColor, _blend);

            foreach (var r in _renderers)
                r.color = new Color(color.r, color.g, color.b, r.color.a);;
        }
    }
}