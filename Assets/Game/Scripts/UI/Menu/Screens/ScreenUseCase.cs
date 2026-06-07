using System;
using System.Collections.Generic;
using Atomic.Elements;

namespace Game.UI
{
    public static class ScreenUseCase
    {
        public static void ShowScreen<T>(this IMenuUI menuUI)
            where T : IScreenPresenter =>
            ShowScreen(menuUI, typeof(T));

        public static void ShowScreen(IMenuUI menuUI, Type screenType)
        {
            IDictionary<Type, IScreenPresenter> screens = menuUI.GetScreens();
            IReactiveVariable<IScreenPresenter> currentScreenPtr = menuUI.GetCurrentScreen();

            //Hide previous screen
            IScreenPresenter previousScreen = currentScreenPtr.Value;
            if (previousScreen != null) 
                menuUI.DelBehaviour(previousScreen);

            //Show next screen
            IScreenPresenter nextScreen = screens[screenType];
            menuUI.AddBehaviour(nextScreen);
            currentScreenPtr.Value = nextScreen;
        }
    }
}