using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TakeDamageBloodBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private readonly ParticleSystem _bloodVfx;
        private readonly TeamCatalog _teamCatalog;

        private ISignal<int> _damageEvent;
        private IValue<TeamType> _teamType;

        public TakeDamageBloodBehaviour(TeamCatalog teamCatalog, ParticleSystem bloodVfx)
        {
            _teamCatalog = teamCatalog;
            _bloodVfx = bloodVfx;
        }

        public void Init(IGameEntity entity)
        {
            _teamType = entity.GetTeam();
            _damageEvent = entity.GetTakeDamageEvent();
            _damageEvent.OnEvent += this.OnDamageTaken;
        }

        public void Dispose(IGameEntity entity)
        {
            _damageEvent.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int _)
        {
            Color color = _teamCatalog.GetTeam(_teamType.Value).Material.color;
            ParticleSystem[] particles = _bloodVfx.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particle in particles)
            {
                ParticleSystem.MainModule particleMain = particle.main;
                particleMain.startColor = color;
            }

            _bloodVfx.Play(withChildren: true);
        }
    }
}