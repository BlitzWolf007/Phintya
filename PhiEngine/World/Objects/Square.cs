using static SDL2.SDL;
using System;
using System.Numerics;

namespace PhiEngine.World.Objects
{
    public class Square : EmptyObject
    {
        Sprite Sprite;

        public Square()
        {
            Sprite = Sprite.Load("C:\\Users\\matei\\Desktop\\viridev\\water.bmp");
        }

        internal override void Draw()
        {
            SDL_Rect src = new SDL_Rect()
            {
                x = 0,
                y = 0,
                w = Sprite.Width,
                h = Sprite.Height
            };

            Vector2 renderPos = GameContainer.ActiveScene.Camera.TranslateToRenderPos(Transform.Position);

            SDL_Rect dest = new SDL_Rect()
            {
                x = (int)(EngineConstants.Video.ResolutionX / 2 + renderPos.X * EngineConstants.Graphics.UnitPx),
                y = (int)(EngineConstants.Video.ResolutionY / 2 - renderPos.Y * EngineConstants.Graphics.UnitPx),
                w = (int)(EngineConstants.Graphics.UnitPx * Transform.Scale.X),
                h = (int)(EngineConstants.Graphics.UnitPx * Transform.Scale.Y)
            };

            SDL_Point center = new SDL_Point()
            {
                x = 0,
                y = 0,
            };

            SDL_RenderCopyEx(SDLManager.SDLRenderer, Sprite.Texture, ref src, ref dest,
                Transform.Rotation - GameContainer.ActiveScene.Camera.Rotation,
                ref center, SDL_RendererFlip.SDL_FLIP_NONE);
        }
    }
}
