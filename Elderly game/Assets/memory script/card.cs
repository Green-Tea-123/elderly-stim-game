using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class card : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    public Sprite hiddeniconsprite;
    public Sprite iconsprite;
    public bool isSelected;

    public cardcontroller controller;


    public void oncardclick()
    {
        controller.SetSelected(this);
    }


    public void SetIconSprite(Sprite sp)
    {
        iconsprite = sp;
    }

    public void Show()
    {
        iconImage.sprite = iconsprite;
        isSelected = true;
    }

    public void Hide()
    {
        iconImage.sprite = hiddeniconsprite;
        isSelected = false;
    }
}
