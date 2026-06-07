namespace Game.Gameplay
{
    public static class JumpUseCase
    {
        public static void Jump(this IGameEntity entity)
        {
            entity.GetVerticalSpeed().Value = entity.GetJumpForce().Value;
        }
    }
}