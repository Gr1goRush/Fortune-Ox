using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int spritesCount = 4;

    [SerializeField] private SpriteRenderer item;

    private FloatRange positionsBounds;

    private SpriteRenderer itemUnderstudy;
    private bool usingUnderstudy = false;
    private float nextItemPositionX, spriteIndex = -1;

    void Start()
    {
        spriteIndex = Random.Range(0, spritesCount);

        float width = item.bounds.size.x;
        float screenWidth = CameraController.Instance.GetScreenWidth();

        positionsBounds.min = -(screenWidth / 2f) + (width / 2f);
        positionsBounds.max = -(screenWidth / 2f) - (width / 2f);

        item.transform.position = new Vector3(positionsBounds.min, 0f, 0f);
        item.sprite = LoadSprite();
        nextItemPositionX = -(screenWidth / 2f) + (width * 1.5f);

        itemUnderstudy = Instantiate(item, transform);
        itemUnderstudy.transform.position = new Vector3(nextItemPositionX, 0f, 0f);

        itemUnderstudy.sprite = LoadSprite();
    }

    void FixedUpdate()
    {
        Vector3 delta = new Vector3(-moveSpeed * Time.fixedDeltaTime * GameController.Instance.Acceleration, 0f, 0f);

        itemUnderstudy.transform.position += delta;
        item.transform.position += delta;

        SpriteRenderer currentItem = usingUnderstudy ? itemUnderstudy : item;
        if (currentItem.transform.position.x <= positionsBounds.max)
        {
            currentItem.transform.position = new Vector3(nextItemPositionX, 0f, 0f);
            usingUnderstudy = !usingUnderstudy;
        }
    }

    private Sprite LoadSprite()
    {
        //spriteIndex++;
        //if(spriteIndex >= spritesCount)
        //{
        //    spriteIndex = 0;
        //}

        return Resources.Load<Sprite>("Background/Background" + (spriteIndex + 1).ToString());
    }
}
