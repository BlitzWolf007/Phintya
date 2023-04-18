using PhiEngine.World;
using System;
using static SDL2.SDL;

namespace PhiEngine
{
    public class GameContainer
    {
        public static Scene ActiveScene;

        public static void Test()
        {            
            SDLManager.Initialize();
            ActiveScene = Scene.Load("");

            while (true)
            {
                HandleMessages();
                SDLManager.Render();

                ActiveScene.Camera.Rotation += 0.01f;
            }
        }

        public static void HandleMessages()
        {
            SDL_Event e;

            while (SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL_EventType.SDL_QUIT)
                {
                    SDLManager.Destroy(); 
                    SDL_Quit();
                    Environment.Exit(0);
                }
            }
        }
    }
}
