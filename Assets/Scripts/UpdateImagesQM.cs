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
    public Text TextPrevious;
    public Text TextCurrent;
    public Text TextNext;

    public ItemsList items;

    public void UpdateImages() //checks for important inputs each frame
    {
        if (items.items.Count == 0) return;

        if (items.items.Count > 2)
        {
            ImagePrevious.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
            ImageCurrent.sprite = items.items[1].sprite;
            TextCurrent.text = items.items[1].Amount.ToString();
            ImageNext.sprite = items.items[2].sprite;
            TextNext.text = items.items[2].Amount.ToString();
        }

        else if (items.items.Count == 2)
        {
            ImagePrevious.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
            ImageCurrent.sprite = items.items[1].sprite;
            TextCurrent.text = items.items[1].Amount.ToString();
            ImageNext.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
        }

        else if (items.items.Count == 1)
        {
            ImagePrevious.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
            ImageCurrent.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
            ImageNext.sprite = items.items[0].sprite;
            TextPrevious.text = items.items[0].Amount.ToString();
        }
    }
}

