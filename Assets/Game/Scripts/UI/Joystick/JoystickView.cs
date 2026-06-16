using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public sealed class JoystickView : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _handle;
        
        public float Radius => _background.rect.width * 0.5f;

        public event Action<Vector2> OnDragged;
        public event Action OnReleased;

        public void SetHandlePosition(Vector2 localPosition) => _handle.localPosition = localPosition;

        public void OnPointerDown(PointerEventData eventData) => NotifyDrag(eventData);
        
        public void OnDrag(PointerEventData eventData) => NotifyDrag(eventData);

        public void OnPointerUp(PointerEventData eventData) => OnReleased?.Invoke();

        private void NotifyDrag(PointerEventData eventData)
        {
            Canvas canvas = GetComponentInParent<Canvas>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _background,
                eventData.position,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
                out Vector2 localPoint
            );
            OnDragged?.Invoke(localPoint);
        }
    }
}