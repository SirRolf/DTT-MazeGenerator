using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FlorisProjecten.MazeGenerator.Maze
{
    public class MazeManager : MonoBehaviour
    {
        [SerializeField] private InputField _widthInputField, _heightInputField;
        [SerializeField] private GameObject _pathPrefab;

        private PathBehavior[,] _pathNodes = new PathBehavior[0,0];
        private Vector2 _currentLocation;

        private void Update()
        {
            List<Vector2> possibleLocations = new List<Vector2>();
            List<Vector2> possibleNewPaths = new List<Vector2>();
            List<Vector2> possibleOldPaths = new List<Vector2>();
            possibleLocations.Add(new Vector2(_currentLocation.x,_currentLocation.y - 1));
            possibleLocations.Add(new Vector2(_currentLocation.x, _currentLocation.y + 1));
            possibleLocations.Add(new Vector2(_currentLocation.x - 1, _currentLocation.y));
            possibleLocations.Add(new Vector2(_currentLocation.x + 1, _currentLocation.y));
            for (int i = 0; i < possibleLocations.Count; i++)
            {
                if (possibleLocations[i].x < 0 || possibleLocations[i].x > _pathNodes.GetLength(0) || possibleLocations[i].y < 0 || possibleLocations[i].y > _pathNodes.GetLength(1))
                {
                    possibleOldPaths.Add(possibleLocations[i]);
                    continue;
                }
                if (_pathNodes[(int)possibleLocations[i].x, (int)possibleLocations[i].y] == null)
                {
                    possibleNewPaths.Add(possibleLocations[i]);
                }
            }
            if (possibleNewPaths.Count != 0)
            {
                Vector2 nextLocation = possibleNewPaths[Random.Range(0, possibleNewPaths.Count)];
                var newPath = Instantiate(_pathPrefab, transform).GetComponent<PathBehavior>();
                newPath.Init(nextLocation, _currentLocation);
                _pathNodes[(int)nextLocation.x, (int)nextLocation.y] = newPath;
                _currentLocation = nextLocation;
            }
            else
            {
                Vector2 nextLocation = possibleLocations[Random.Range(0, possibleLocations.Count)];
            }
        }

        public void NewMaze()
        {
            _pathNodes = new PathBehavior[int.Parse(_widthInputField.text), int.Parse(_heightInputField.text)];
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            _currentLocation = new Vector2();
        }
    }
}
