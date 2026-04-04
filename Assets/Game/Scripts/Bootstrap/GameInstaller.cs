using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private InputControls _inputControls;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform _coinContainer;
        [SerializeField] int _maxDifficulty = 9;
        
        public override void InstallBindings()
        {
            InstallModules();
            InstallInput();
            InstallGameplayMechanics();
            InstallPool();
            InstallUI();
        }

        private void InstallGameplayMechanics()
        {
            Container.Bind<GameCycle>().AsSingle();

            Container.BindInterfacesAndSelfTo<OutOfBordersController>().AsCached();
            Container.BindInterfacesAndSelfTo<SelfCollisionController>().AsCached();

            Container.BindInterfacesAndSelfTo<CoinPickupController>().AsCached();
            Container.BindInterfacesAndSelfTo<SnakeExpandController>().AsCached();
            Container.BindInterfacesAndSelfTo<ScoreController>().AsCached();

            Container.BindInterfacesAndSelfTo<CoinSpawnController>().AsCached();
            Container.BindInterfacesAndSelfTo<SnakeSpeedController>().AsCached();
            Container.BindInterfacesAndSelfTo<DifficultyController>().AsCached();

            Container.Bind<CoinManager>().AsSingle();
        }

        private void InstallModules()
        {
            Container.BindInterfacesTo<Snake>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<WorldBounds>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<Score>().AsSingle();
            Container.BindInterfacesTo<Difficulty>().AsSingle().WithArguments(_maxDifficulty);
        }

        private void InstallInput()
        {
            Container.Bind<InputControls>().FromScriptableObject(_inputControls).AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeController>().AsCached();
        }

        private void InstallPool()
        {
            Container.BindMemoryPool<Coin>().
                WithInitialSize(_maxDifficulty).
                WithMaxSize(_maxDifficulty).
                FromComponentInNewPrefab(_coinPrefab).
                UnderTransform(_coinContainer).
                AsSingle().
                OnInstantiated<Coin>((_, coin) => coin.gameObject.SetActive(false));
        }

        private void InstallUI()
        {
            Container.BindInterfacesTo<GameUI>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameUIController>().AsCached();
        }
    }
}