using Atomic.Elements;

namespace Game.App
{
    public static class LevelsUseCase
    {
        public static void TryIncrementLevel(this IAppContext context)
        {
            IVariable<int> currentLevel = context.GetCurrentLevel();
            IValue<int> maxLevel = context.GetMaxLevel();
            if (currentLevel.Value < maxLevel.Value) 
                currentLevel.Value++;
        }
    }
}