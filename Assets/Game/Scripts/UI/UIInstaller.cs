using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private ItemPopupView _itemPopup;

        public override void InstallBindings()
        {
            Container.Bind<ItemPopupPresenter>().AsSingle().WithArguments(_itemPopup);
        }
    }
}