using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Events;


public class UpdateImagesQM : MonoBehaviour
{

    public Image ImagePrevious; 
    public Image ImageCurrent;
    public Image ImageNext; 

    public List<Item> items;

    public UnityEvent SwipeRight;
    public UnityEvent SwipeLeft;
    public UnityEvent Use;

    void Update() //checks for important inputs each frame
    {
        if (items.Count == 0) return;

        if (items.Count > 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[1].sprite;
            ImageNext.sprite = items[2].sprite;
        }

        else if (items.Count == 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[1].sprite;
            ImageNext.sprite = items[0].sprite;
        }

        else if (items.Count == 1)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[0].sprite;
            ImageNext.sprite = items[0].sprite;
        }
    }
}

