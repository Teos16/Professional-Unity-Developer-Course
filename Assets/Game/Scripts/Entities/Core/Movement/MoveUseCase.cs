using Atomic.Entities;
using SampleGame;

namespace Game
{
    public static class MoveUseCase
    {
        public static void MoveStep(this IEntity entity, float deltaTime) => 
            entity.GetPosition().Value += entity.GetMoveDirection().Value * entity.GetMoveSpeed().Value * deltaTime;
    }
}