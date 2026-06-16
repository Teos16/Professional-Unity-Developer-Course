using Atomic.Entities;

namespace Game.Gameplay
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IGameEntity interactor, IGameEntity interactable)
        {
            if (interactable.IsInteractable())
                interactable.GetValue(GameEntityAPI.InteractCommand).Invoke(interactor);
        }

        public static bool IsInteractable(this IGameEntity entity) => 
            entity != null && entity.HasTag(GameEntityAPI.InteractableTag);
    }
}