using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FlorisProjecten.MazeGenerator.CameraBehavior;

namespace FlorisProjecten.MazeGenerator.Maze
{
    public class MazeManager : MonoBehaviour
    {
        [SerializeField] private InputField _widthInputField, _heightInputField;
        [SerializeField] private GameObject _pathPrefab;
        [SerializeField] private GameObject _camera;
        [SerializeField] private float _delay;

        private PathBehavior[,] _pathNodes = new PathBehavior[0,0];
        private Vector2 _currentLocation;
        private float _time;

        private void Update()
        {
            _time += Time.deltaTime;
            if (_time > _delay)
            {
                NextPath();
                _time = 0;
            }
        }
        /// <summary>
        /// Checks if there are empty path location nearby. When he can't find any he will check if there are any non checked paths nearby. The maze is done if he cannot find one of those either.
        /// </summary>
        private void NextPath()
        {
            List<Vector2> possibleLocations = new List<Vector2>();
            List<Vector2> possibleNewPaths = new List<Vector2>();
            List<Vector2> possibleNewCheck = new List<Vector2>();
            List<Vector2> possibleOldPaths = new List<Vector2>();
            possibleLocations.Add(new Vector2(_currentLocation.x, _currentLocation.y - 1));
            possibleLocations.Add(new Vector2(_currentLocation.x, _currentLocation.y + 1));
            possibleLocations.Add(new Vector2(_currentLocation.x - 1, _currentLocation.y));
            possibleLocations.Add(new Vector2(_currentLocation.x + 1, _currentLocation.y));
            for (int i = 0; i < possibleLocations.Count; i++)
            {
                if (possibleLocations[i].x < 0 || possibleLocations[i].x > _pathNodes.GetLength(0) - 1 || possibleLocations[i].y < 0 || possibleLocations[i].y > _pathNodes.GetLength(1) - 1)
                {
                    continue;
                }
                possibleOldPaths.Add(possibleLocations[i]);
                if (_pathNodes[(int)possibleLocations[i].x, (int)possibleLocations[i].y] == null)
                {
                    possibleNewPaths.Add(possibleLocations[i]);
                }
                else if (_pathNodes[(int)possibleLocations[i].x, (int)possibleLocations[i].y].State == States.CheckedOnce)
                {
                    possibleNewCheck.Add(_pathNodes[(int)_currentLocation.x, (int)_currentLocation.y].ConnectedPath);
                }
            }
            if (possibleNewPaths.Count != 0)
            {
                Vector2 nextLocation = possibleNewPaths[Random.Range(0, possibleNewPaths.Count)];
                var newPath = Instantiate(_pathPrefab, transform).GetComponent<PathBehavior>();
                newPath.Init(nextLocation, _currentLocation);
                _camera.GetComponent<ZoomOut>().ChangeSize(newPath.transform);
                _pathNodes[(int)nextLocation.x, (int)nextLocation.y] = newPath;
                _currentLocation = nextLocation;
            }
            else
            {
                Vector2 nextLocation = possibleNewCheck[Random.Range(0, possibleNewCheck.Count)];
                _pathNodes[(int)_currentLocation.x, (int)_currentLocation.y].ChangeState();
                _currentLocation = nextLocation;
            }
        }

        /// <summary>
        /// Resets position, destroys all the paths and checks how big the maze should be.
        /// </summary>
        public void NewMaze()
        {
            //Should have done this with an Action.
            _pathNodes = new PathBehavior[int.Parse(_widthInputField.text), int.Parse(_heightInputField.text)];
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            _currentLocation = new Vector2();
        }
    }
}
