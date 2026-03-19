using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.UI
{
    public interface IItemPopupView
    {
        event UnityAction OnConsumeClicked;
        event UnityAction OnCloseClicked;
        void SetTitle(string title);
        void SetDescription(string description);
        void SetCount(string count);
        void SetIcon(Sprite icon);
        void SetConsumable(bool consumable);
        void SetConsumeAllowed(bool allowed);
        void Show();
        void Hide();
    }
}