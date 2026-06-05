using System;
using System.Collections.Generic;
using Atomic.Elements;

namespace Game.UI
{
    public static class ScreenUseCase
    {
        public static void ShowScreen<T>(this IMenuUI menuContext)
            where T : IScreenPresenter =>
            ShowScreen(menuContext, typeof(T));

        public static void ShowScreen(IMenuUI menuContext, Type screenType)
        {
            IDictionary<Type, IScreenPresenter> screens = menuContext.GetScreens();
            IReactiveVariable<IScreenPresenter> currentScreenPtr = menuContext.GetCurrentScreen();

            //Hide previous screen
            IScreenPresenter previousScreen = currentScreenPtr.Value;
            if (previousScreen != null) 
                menuContext.DelBehaviour(previousScreen);

            //Show next screen
            IScreenPresenter nextScreen = screens[screenType];
            menuContext.AddBehaviour(nextScreen);
            currentScreenPtr.Value = nextScreen;
        }
    }
}