using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ZombieViewInstaller : GameEntityInstaller
    {
        [SerializeField] private EntityAnimationInstaller _animationInstaller;
        [SerializeField] private EntityVFXInstaller entityVFXInstaller;
        [SerializeField] private EntityAudioInstaller _audioInstaller;
        
        public override void Install(IGameEntity entity)
        {
            _animationInstaller.Install(entity);
            entityVFXInstaller.Install(entity);
            _audioInstaller.Install(entity);
        }

        public override void Uninstall(IGameEntity entity)
        {
            _animationInstaller.Uninstall(entity);
            entityVFXInstaller.Uninstall(entity);
            _audioInstaller.Uninstall(entity);
        }
    }
}