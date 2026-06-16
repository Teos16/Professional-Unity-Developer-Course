using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ZombieViewInstaller : GameEntityInstaller
    {
        [SerializeField] private GameEntityAnimationInstaller _animationInstaller;
        [SerializeField] private GameEntityVFXInstaller _vfxInstaller;
        [SerializeField] private GameEntityAudioInstaller _audioInstaller;
        
        public override void Install(IGameEntity entity)
        {
            _animationInstaller.Install(entity);
            _vfxInstaller.Install(entity);
            _audioInstaller.Install(entity);
        }

        public override void Uninstall(IGameEntity entity)
        {
            _animationInstaller.Uninstall(entity);
            _vfxInstaller.Uninstall(entity);
            _audioInstaller.Uninstall(entity);
        }
    }
}