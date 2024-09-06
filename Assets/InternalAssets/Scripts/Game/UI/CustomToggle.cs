using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomToggle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image _image;
    public Sprite onSprite, offSprite;

    bool isOn;
    public bool IsOn
    {
        get { return isOn; }
        set { isOn = value; SetValue(isOn); }
    }

    public UnityEvent<bool> onValueChanged;

    void SetValue(bool v)
    {
        if (v)
        {
            _image.sprite = onSprite;
        }
        else
        {
            _image.sprite = offSprite;
        }

        onValueChanged?.Invoke(v);
    }

    void ChangeValue()
    {
        IsOn = !IsOn;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ChangeValue();
    }

    private void Reset()
    {
        _image = GetComponent<Image>();
    }
}
