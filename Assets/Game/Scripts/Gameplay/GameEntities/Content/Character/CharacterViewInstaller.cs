using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterViewInstaller : GameEntityInstaller
    {
        private const string NAME_FORMAT = "Character ({0})";

        private static readonly int Death = Animator.StringToHash(nameof(Death));
        private static readonly int Fire = Animator.StringToHash(nameof(Fire));
        private static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        private static readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));
        private static readonly int Health = Animator.StringToHash(nameof(Health));
        private static readonly int Respawn = Animator.StringToHash("Respawn");

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GameObject _weaponVisual;

        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private TeamCatalog _teamCatalog;

        [SerializeField]
        private ParticleSystem _bloodVfx;

        [Header("Canvas")]
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private HealthView _healthView;

        [Header("Audio")]
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _damageClip;

        [SerializeField]
        private AudioClip _deathClip;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            entity
                .WhenTick(_ => _animator.SetBool(IsMoving, entity.IsMoving()))
                .AddTo(_disposables);

            entity
                .GetTeam()
                .Observe(team => _renderer.material = _teamCatalog.GetTeam(team).Material)
                .AddTo(_disposables);

            entity
                .GetTeam()
                .Observe(team => entity.Name = string.Format(NAME_FORMAT, team))
                .AddTo(_disposables);

            entity
                .GetWeapon()
                .Observe(weapon => _weaponVisual.SetActive(weapon != null))
                .AddTo(_disposables);

            entity
                .GetFireEvent()
                .Subscribe(() => _animator.SetTrigger(Fire))
                .AddTo(_disposables);

            entity
                .GetTakeDamageEvent()
                .Subscribe(_ =>
                {
                    if(entity.DoesHealthExist())
                        _animator.SetTrigger(TakeDamage);
                })
                .AddTo(_disposables);

            entity
                .GetTakeDamageEvent()
                .Subscribe(_ => _audioSource.PlayOneShot(_damageClip))
                .AddTo(_disposables);

            entity
                .GetDeathEvent()
                .Subscribe(() => _audioSource.PlayOneShot(_deathClip))
                .AddTo(_disposables);
            
            entity
                .WhenTick(_ => _animator.SetInteger(Health, entity.GetHealth().Value))
                .AddTo(_disposables);

            GameContext gameContext = GameContext.Instance;
            entity.AddBehaviour(new CameraBillboardBehaviour(gameContext, _canvas.transform));
            entity.AddBehaviour(new HealthViewBehaviour(_healthView, _teamCatalog));
            entity.AddBehaviour(new TakeDamageBloodBehaviour(_teamCatalog, _bloodVfx));
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}