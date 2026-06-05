using Cysharp.Threading.Tasks;
using Game.App;
using UnityEngine;

namespace Game
{
    public sealed class MenuLoadController : IAppContextTick
    {
        public void Tick(IAppContext entity, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !entity.InMenu())
            {
                Debug.Log("LOAD MENU");
                entity.LoadMenu().Forget();
            }
        }
    }
}