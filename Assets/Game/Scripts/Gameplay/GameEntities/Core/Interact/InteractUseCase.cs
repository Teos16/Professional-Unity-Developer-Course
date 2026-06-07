namespace Game.Gameplay
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IGameEntity character, IGameEntity interactible)
        {
            if (interactible.IsInteractible())
                interactible.GetInteractCommand().Invoke(character);
        }

        public static bool IsInteractible(this IGameEntity entity) => entity != null && entity.HasInteractibleTag();
    }
}