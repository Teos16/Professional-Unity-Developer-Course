using Atomic.Entities;

namespace Game
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IEntity character, IEntity interactible)
        {
            if (interactible != null 
                && interactible.HasInteractibleTag() 
                && interactible.GetInteractCondition().Invoke(character))
            {
                interactible.GetInteractAction().Invoke(character);
                interactible.GetInteractEvent()?.Invoke(character);
            }
        }
        
        public static bool IsInteractible(this IEntity entity) => entity.HasInteractibleTag();
    }
}