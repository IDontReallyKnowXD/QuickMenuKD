using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Events;


public class UpdateSpritesQM : MonoBehaviour
{

    public ItemsList items;

    public UnityEvent updateImages;

    public void UpdateSprites() 
    {
        if (items.items.Count == 0) return;
        ItemQM currentItem = items.items[1];
        if (items.items.Count == 1)
        {
            currentItem = items.items[0];
        }
        if (Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.uses) != null)
        {
            items.items[1].sprite = Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.uses);
        }
        updateImages.Invoke();

    }
}
