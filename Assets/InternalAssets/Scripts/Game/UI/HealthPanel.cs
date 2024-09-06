using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite[] sprites;

    public void SetSprite(int index)
    {
        _image.sprite = sprites[index];
    }
}