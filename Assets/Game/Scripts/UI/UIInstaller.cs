using SampleGame.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private ItemPopupView _itemPopup;
        [SerializeField] private InventoryPopupView _inventoryPopup;
        [SerializeField] private ItemCardView _card;
        [SerializeField] private Transform _pool;
        [SerializeField] private Button _inventoryButton;
        
        public override void InstallBindings()
        {
            Container.Bind<ItemPopupPresenter>().AsSingle().WithArguments(_itemPopup);
            Container.Bind<InventoryPopupPresenter>().AsSingle().WithArguments(_inventoryPopup);
            
            Container
                .BindFactory<Item, ItemCardView, ItemCardPresenter, ItemCardPresenter.Factory>()
                .AsSingle();
            
            Container
                .BindMemoryPool<ItemCardView, ItemCardView.Pool>()
                .FromComponentInNewPrefab(_card)
                .UnderTransform(_pool)
                .AsCached();
            
            Container
                .BindInterfacesAndSelfTo<InventoryButtonPresenter>()
                .AsCached()
                .WithArguments(_inventoryButton);
        }
    }
}
