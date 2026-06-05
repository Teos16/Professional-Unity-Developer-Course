namespace Game.Gameplay
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IGameEntity character, IGameEntity interactible)
        {
            if (interactible != null && interactible.HasInteractibleTag() &&
                interactible.GetInteractCondition().Invoke(character))
            {
                interactible.GetInteractAction().Invoke(character);
                interactible.GetInteractEvent()?.Invoke(character);
            }
        }

        public static bool IsInteractible(this IGameEntity entity) => entity.HasInteractibleTag();
    }
}