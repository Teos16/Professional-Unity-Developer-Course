using System;
using System.Collections.Generic;
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
        private static readonly int Respawn = Animator.StringToHash(nameof(Respawn));
        private static readonly int SpeedMultiplier = Animator.StringToHash(nameof(SpeedMultiplier));

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GameObject _weaponVisual;

        [SerializeField]
        private GameObject _mainVisual;

        [SerializeField]
        private GameObject _sheepVisual;
        
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
            entity.AddAnimator(_animator);
            
            entity.GetIsSheep().Observe(isSheep =>
            {
                _mainVisual.SetActive(!isSheep);
                _sheepVisual.SetActive(isSheep);
            }).AddTo(_disposables);
            
            entity
                .WhenTick(_ => _animator.SetBool(IsMoving, entity.IsMoving()))
                .AddTo(_disposables);

            entity
                .GetTeam()
                .Observe(team =>
                {
                    _renderer.material = _teamCatalog.GetTeam(team).Material;
                    entity.Name = string.Format(NAME_FORMAT, team);
                })
                .AddTo(_disposables);

            entity
                .GetWeapon()
                .Observe(weapon => _weaponVisual.SetActive(weapon != null))
                .AddTo(_disposables);

            // Subscription
            entity
                .GetFireCommand()
                .Subscribe(() => _animator.SetTrigger(Fire))
                .AddTo(_disposables);

            entity
                .GetTakeDamageCommand()
                .Subscribe(_ =>
                {
                    _animator.SetTrigger(TakeDamage);
                    _audioSource.PlayOneShot(_damageClip);
                })
                .AddTo(_disposables);

            entity
                .GetDeathEvent()
                .Subscribe(() =>
                {
                    _animator.SetTrigger(Death);
                    _audioSource.PlayOneShot(_deathClip);
                })
                .AddTo(_disposables);

            entity
                .GetRespawnCommand()
                .Subscribe(() => _animator.SetTrigger(Respawn))
                .AddTo(_disposables);
            
            entity
                .GetMoveSpeedMultiplier()
                .SubscribeState(x => _animator.SetFloat(SpeedMultiplier, x))
                .AddTo( _disposables);
            
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