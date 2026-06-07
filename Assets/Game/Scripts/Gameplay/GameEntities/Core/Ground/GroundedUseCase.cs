namespace Game.Gameplay
{
    public static class GroundedUseCase
    {
        public static bool IsGrounded(this IGameEntity entity)
        {
            return entity.GetPosition().Value.y <= 0;
        }
    }
}