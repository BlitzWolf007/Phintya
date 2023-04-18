using PhiEngine.World.Objects.Components;

namespace PhiEngine.World.Objects
{
    public abstract class EmptyObject
    {
        public Transform Transform;

        public EmptyObject()
        {
            Transform = new Transform();
        }

        abstract internal void Draw();
    }
}
