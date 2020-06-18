using UnityEngine;

namespace FlorisProjecten.MazeGenerator.Maze
{
    public class PathBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject _runWay;
        public States State;

        public void Init(Vector2 newLocation, Vector2 oldLocation)
        {
            transform.position = new Vector3(newLocation.x * 2 - 1, 0, newLocation.y * 2 - 1);
        }
    }
}
