using Modules.Popups;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private ItemCardPresenter _card;
        [SerializeField] private Transform _pool;
        
        public override void InstallBindings()
        {
            Container
                .Bind<PopupManager>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container
                .Bind<PopupCatalog>()
                .FromScriptableObjectResource(nameof(PopupCatalog))
                .AsSingle();
            
            Container
                .BindMemoryPool<ItemCardPresenter, ItemCardPresenter.Pool>()
                .FromComponentInNewPrefab(_card)
                .UnderTransform(_pool)
                .AsCached();
        }
    }
}
