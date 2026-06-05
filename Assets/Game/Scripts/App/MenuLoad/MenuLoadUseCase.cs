using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App
{
    public static class MenuLoadUseCase
    {
        private const string MENU_NAME = "Game (Menu)";
        
        public static async UniTask LoadMenu(this IAppContext appContext)
        {
            await SceneManager.LoadSceneAsync(MENU_NAME);
            appContext.GetMenuLoadedEvent().Invoke();
        }

        public static bool InMenu(this IAppContext appContext)
        {
            return SceneManager.GetActiveScene().name == MENU_NAME;
        }
    }
}