
namespace Game.Gameplay
{
    public static class GameCycleUseCase
    {
        public static bool IsPlaying(this IGameContext context) => context.GetGameTime().Value > 0;
    }
}