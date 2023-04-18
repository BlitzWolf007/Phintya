using static SDL2.SDL_image;
using static SDL2.SDL;
using System;

namespace PhiEngine
{
    public class Sprite : IDisposable 
    {
        public int Width, Height;
        public IntPtr Raw;
        public IntPtr Texture;

        private Sprite(IntPtr raw)
        {
            Raw = raw;
            Texture = SDL_CreateTextureFromSurface(SDLManager.SDLRenderer, Raw);
            SDL_QueryTexture(Texture, out _, out _, out Width, out Height);
        }

        public static Sprite Load(string path)
        {
            IntPtr img = IMG_Load(path);
            Sprite sprite = new Sprite(img);

            return sprite;
        }

        public void Dispose()
        {
            SDL_FreeSurface(Raw);
            SDL_DestroyTexture(Texture);
        }
    }
}
