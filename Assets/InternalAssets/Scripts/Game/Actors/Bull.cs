using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bull : Actor
{
    [Space]
    [SerializeField] public int health = 3;

    [SerializeField] public Sprite[] damageSprites;

    private int currentHealth;

    private float verticalBound;

    private bool isTouching = false;
    private float movingDirection = 0f;

    void Start()
    {
        currentHealth = health;

        verticalBound = GetVerticalScreenBound();
    }

    void Update()
    {
        isTouching = InputController.Instance.Touching();
        movingDirection = isTouching ? Mathf.Sign(InputController.Instance.GetTouchWorldPosition().y) : 0f ;
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            Vector2 position = _rigidbody.position + new Vector2(0f, movingDirection * moveSpeed * Time.fixedDeltaTime);
            position.y = Mathf.Clamp(position.y, -verticalBound, verticalBound);
            _rigidbody.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentHealth <= 0)
        {
            return;
        }

        if (collision.TryGetComponent(out BullfighterPullObject bullfighter))
        {
            currentHealth -= 1;
            if(currentHealth <= 0)
            {
                Death();
            }

            int spriteIndex = damageSprites.Length - currentHealth - 1;
            spriteRenderer.sprite = damageSprites[spriteIndex];
            UIController.Instance.HealthPanel.SetSprite(spriteIndex);

            bullfighter.UnpullThis();
        }
    }

    private void Death()
    {
        GameController.Instance.GameOver();
    }
}
