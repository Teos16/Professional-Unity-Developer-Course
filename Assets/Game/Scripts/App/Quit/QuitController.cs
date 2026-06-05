using UnityEngine;

namespace Game.App
{
    public sealed class QuitController : IAppContextTick
    {
        public void Tick(IAppContext context, float deltaTime)
        {
            if (Input.GetKey(KeyCode.Escape) && context.InMenu()) 
                context.Quit();
        }
    }
}