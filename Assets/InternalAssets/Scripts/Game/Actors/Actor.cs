using System.Collections;
using UnityEngine;

public class Actor : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 1f;

    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected void MoveWithCommonAcceleration(Vector2 delta)
    {
        _rigidbody.position += delta * GameController.Instance.Acceleration;
    }

    protected float GetHeight()
    {
        return spriteRenderer.bounds.size.y;
    }

    public float GetVerticalScreenBound()
    {
        float screenHeight = CameraController.Instance.GetScreenHeight();
        float bullHeight = GetHeight();

        return (screenHeight / 2f) - (bullHeight / 2f);

    }
}