using System.Collections.Generic;
using UnityEngine;

namespace FlorisProjecten.MazeGenerator.CameraBehavior
{
    [RequireComponent(typeof(Camera))]
    public class ZoomOut : MonoBehaviour
    {
        private Camera _camera;
        Dictionary<string, Transform> _furthestPaths = new Dictionary<string, Transform>();
        private void Start()
        {
            _camera = GetComponent<Camera>();
            _furthestPaths.Add("up", null);
            _furthestPaths.Add("down", null);
            _furthestPaths.Add("left", null);
            _furthestPaths.Add("right", null);
        }

        private void Update()
        {
            // check if all the furthest paths are visable
            if (_camera.WorldToScreenPoint(_furthestPaths["up"].position).y > _camera.pixelHeight)
            {
                _camera.orthographicSize += 0.01f;
            }
            else if (_camera.WorldToScreenPoint(_furthestPaths["down"].position).y < 0)
            {
                _camera.orthographicSize += 0.01f;
            }
            else if (_camera.WorldToScreenPoint(_furthestPaths["right"].position).x > _camera.pixelWidth)
            {
                _camera.orthographicSize += 0.01f;
            }
            else if (_camera.WorldToScreenPoint(_furthestPaths["left"].position).x < 0)
            {
                _camera.orthographicSize += 0.01f;
            }
        }

        // Whenever you add a new path also check if i'ts further away then other paths.
        private void ChangeSize(Transform transform)
        {
            if (_furthestPaths["up"].position.z > transform.position.z) _furthestPaths["up"] = transform;
            if (_furthestPaths["down"].position.z < transform.position.z) _furthestPaths["down"] = transform;
            if (_furthestPaths["left"].position.x < transform.position.x) _furthestPaths["left"] = transform;
            if (_furthestPaths["right"].position.x > transform.position.x) _furthestPaths["right"] = transform;
        }
    }
}
