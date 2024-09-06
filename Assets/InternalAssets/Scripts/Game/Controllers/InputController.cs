using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InputController : Singleton<InputController>
{

    Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();

        mainCamera = Camera.main;
    }

    public bool Touching()
    {
        if (Input.touchSupported)
        {
            return Input.touchCount > 0;
        }
        else
        {
            return Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);
        }
    }

    public Vector3 GetTouchWorldPosition()
    {
        Vector2 touchPos = GetTouchPosition();
        return mainCamera.ScreenToWorldPoint(touchPos);
    }

    Vector2 GetTouchPosition()
    {
        if (Input.touchSupported)
        {
            return Input.GetTouch(0).position;
        }
        else
        {
            return Input.mousePosition;
        }
    }
}