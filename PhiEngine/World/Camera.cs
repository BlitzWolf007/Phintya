using System;
using System.Numerics;

namespace PhiEngine.World
{
    public class Camera
    {
        public Vector3 Position;
        public float Rotation;

        public Matrix4x4 Matrix
        {
            get
            {
                // generate matrix for given position and rotation
                Matrix4x4 matrix = Matrix4x4.CreateTranslation(Position)
                                 * Matrix4x4.CreateRotationX(Rotation);
                return matrix;
            }
        }

        public Vector2 TranslateToRenderPos(Vector2 objPos)
        {
            // create obj matrix
            Matrix3x2 objMatrix = Matrix3x2.CreateTranslation(objPos);

            // create camera matrix
            // x is negative because x coords increase to the right, exactly as video pixel coords do 
            // y is positive because y coords increase upwards, contrary to how video pixel coords do 
            Matrix3x2 camMatrix = Matrix3x2.CreateTranslation(-Position.X, Position.Y) // we must substract camera movement
                                * Matrix3x2.CreateRotation((float)Math.PI * Rotation / 180f); // take camerat rotation

            Matrix3x2 finalMatrix = objMatrix * camMatrix;

            return new Vector2(finalMatrix.M31, finalMatrix.M32);
        }

        public Camera()
        {
            Position = new Vector3();
            Rotation = 0;
        }
    }
}
