using System.Collections;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Camera _camera;

    public float GetScreenHeight()
    {
        return _camera.orthographicSize * 2;
    }

    public float GetScreenWidth()
    {
        return _camera.orthographicSize * 2 * _camera.aspect;
    }
}