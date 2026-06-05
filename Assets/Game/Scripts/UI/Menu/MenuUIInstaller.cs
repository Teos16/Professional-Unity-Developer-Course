using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using AppContext = Game.App.AppContext;

namespace Game.UI
{
    public sealed class MenuUIInstaller : SceneEntityInstaller<IMenuUI>
    {
        [SerializeField]
        private StartScreenPresenter _startScreen;

        [SerializeField]
        private LevelScreenPresenter _levelScreen;

        public override void Install(IMenuUI ui)
        {
            ui.AddScreens(new Dictionary<Type, IScreenPresenter>
            {
                {typeof(StartScreenPresenter), _startScreen},
                {typeof(LevelScreenPresenter), _levelScreen}
            });
            ui.AddCurrentScreen(new ReactiveVariable<IScreenPresenter>());
            ui.AddBehaviour(new MenuUIController(AppContext.Instance));
        }
    }
}