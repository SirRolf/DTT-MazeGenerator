using UnityEngine;

namespace FlorisProjecten.MazeGenerator.Maze
{
    public class PathBehavior : MonoBehaviour
    {
        // should use getter setters
        [HideInInspector] public States State;
        [HideInInspector] public Vector2 ConnectedPath;

        [SerializeField] private GameObject _runWay;
        [SerializeField] private Material _checkedGround;

        private Renderer _childRenderer;

        /// <summary>
        /// Function that moves the path to  the correct location and adds a runway to it
        /// </summary>
        /// <param name="newLocation"></param>
        /// <param name="oldLocation"></param>
        public void Init(Vector2 newLocation, Vector2 oldLocation)
        {
            ConnectedPath = oldLocation;
            transform.position = new Vector3(newLocation.x * 2 - 1, 0, newLocation.y * 2 - 1);
            //could have maybee done this calculation in a seprate variable
            GameObject child = Instantiate(_runWay, new Vector3((transform.position.x + (oldLocation.x *2 - 1)) / 2, 0, (transform.position.z + (oldLocation.y * 2 - 1)) / 2), Quaternion.identity, transform);
            _childRenderer = child.GetComponent<Renderer>();
        }

        /// <summary>
        /// Changes the state of this path. This also changes the material
        /// </summary>
        public void ChangeState()
        {
            GetComponent<Renderer>().material = _checkedGround;
            //there must be a better way of doing this but GetComponentInChild didn't work for me 
            _childRenderer.material = _checkedGround;
            State = States.CheckedTwice;
        }
    }
}
