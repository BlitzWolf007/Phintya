using System;
using System.Numerics;

namespace PhiEngine.World
{
    public class Camera
    {
        /// <summary>
        /// X, Y and Z (zoom level) coordinates.
        /// </summary>
        public Vector3 Position;
        public float Rotation;

        public Vector2 TranslateToRenderPos(Vector2 objPos)
        {
            // create obj matrix
            Matrix3x2 objMatrix = Matrix3x2.CreateTranslation(objPos);

            // create camera matrix
            // y is added because y coords increase upwards, contrary to how video pixel coords do 
            Matrix3x2 camMatrix = Matrix3x2.CreateTranslation(-Position.X, Position.Y) // we must substract camera movement
                                * Matrix3x2.CreateRotation((float)Math.PI * Rotation / 180f); // take camerat rotation into consideration

            Matrix3x2 finalMatrix = objMatrix * camMatrix;

            Vector2 renderPos = new Vector2(EngineConstants.Video.ResolutionX / 2 + finalMatrix.M31 * EngineConstants.Graphics.UnitPx,  // x
                                            EngineConstants.Video.ResolutionY / 2 - finalMatrix.M32 * EngineConstants.Graphics.UnitPx); // y
            

            return renderPos;
        }

        public Camera()
        {
            Position = new Vector3();
            Rotation = 0;
        }
    }
}
