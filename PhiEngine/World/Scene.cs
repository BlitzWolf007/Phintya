using PhiEngine.World.Objects;
using System.Collections.Generic;
using System.Numerics;

namespace PhiEngine.World
{
    public class Scene
    {
        public Camera Camera;
        public List<EmptyObject> SceneObjects;

        private Scene()
        {
            Camera = new Camera();
            SceneObjects = new List<EmptyObject>();
        }

        /// <summary>
        /// Loads a scene from a given file. The game's active scene will not be changed.
        /// </summary>
        public static Scene Load(string path)
        {            
            Scene s = new Scene();

            s.SceneObjects.Add(new Square());
            s.SceneObjects.Add(new Square());
            s.SceneObjects.Add(new Square());
            s.SceneObjects[0].Transform.Position = new Vector2(0, 0);
            s.SceneObjects[1].Transform.Position = new Vector2(3, 0);
            s.SceneObjects[2].Transform.Position = new Vector2(5, 3);

            s.Camera.Rotation = 0f;

            return s;
        }
    }
}
