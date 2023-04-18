using static SDL2.SDL;
using System;
using PhiEngine.World.Objects;

namespace PhiEngine
{
    internal static class SDLManager
    {
        public static IntPtr SDLWindow;
        public static IntPtr SDLRenderer;

        public static void Initialize()
        {
            if (SDL_Init(SDL_INIT_VIDEO) == 0)
            {
                SDLWindow = SDL_CreateWindow(EngineConstants.Game.Name,
                    SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
                    EngineConstants.Video.ResolutionX, EngineConstants.Video.ResolutionY,
                    SDL_WindowFlags.SDL_WINDOW_SHOWN);
                SDLRenderer = SDL_CreateRenderer(SDLWindow, 0, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            }
            else
            {
                Debug.Error("Could not initialize the SDL window or renderer!");
            }
        }

        static Sprite Sprite = Sprite.Load("D:/poza.bmp");

        public static void Render()
        {
            SDL_SetRenderDrawColor(SDLRenderer, 255, 136, 0, 255);
            SDL_RenderClear(SDLRenderer);
            if (GameContainer.ActiveScene != null)
            {
                foreach (EmptyObject o in GameContainer.ActiveScene.SceneObjects)
                {
                    o.Draw();
                }

                SDL_SetRenderDrawColor(SDLRenderer, 255, 0, 0, 255);
                SDL_RenderDrawLine(SDLRenderer, EngineConstants.Video.ResolutionX / 2, 0, EngineConstants.Video.ResolutionX / 2, EngineConstants.Video.ResolutionY);
                SDL_SetRenderDrawColor(SDLRenderer, 0, 0, 255, 255);
                SDL_RenderDrawLine(SDLRenderer, 0, EngineConstants.Video.ResolutionY / 2, EngineConstants.Video.ResolutionX, EngineConstants.Video.ResolutionY / 2);
            }
            SDL_RenderPresent(SDLRenderer);
        }

        public static void Destroy()
        {
            SDL_DestroyRenderer(SDLRenderer);
            SDL_DestroyWindow(SDLWindow);
        }
    }
}
