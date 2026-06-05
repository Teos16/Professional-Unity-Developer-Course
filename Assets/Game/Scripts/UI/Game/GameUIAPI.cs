using Atomic.Entities;
using TMPro;

namespace Game.UI
{
    public static class GameUIAPI
    {
        public static ValueKey<IGameUI, TMP_Text> CountdownView => new(nameof(CountdownView));
        public static ValueKey<IGameUI, GameOverPopupView> GameOverPopupView => new(nameof(GameOverPopupView));
    }
}