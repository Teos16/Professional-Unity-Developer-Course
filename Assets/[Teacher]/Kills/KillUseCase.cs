// namespace Game.Gameplay
// {
//     public static class KillUseCase
//     {
//         public static void ProcessKill(this IGameContext gameContext, KillArgs killArgs)
//         {
//             if (killArgs.killer != killArgs.victim)
//                 gameContext.GetPlayer(killArgs.killer).GetScore().Value++;
//             
//             gameContext.GetKillEvent().Invoke(killArgs);
//         }
//     }
// }