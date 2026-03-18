using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class UIDebug : MonoBehaviour
    {
        [InjectOptional]
        [ShowInInspector, HideInEditorMode]
        private ItemPopupPresenter _presenter;
    }
}