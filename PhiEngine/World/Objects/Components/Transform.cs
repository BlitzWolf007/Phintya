using System.Numerics;

namespace PhiEngine.World.Objects.Components
{
    public class Transform
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public Transform()
        {
            Reset();
        }

        public void Reset()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Scale = Vector2.One;
        }
    }
}
