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

    public List<Item> items = new List<Item>();

    void Update() 
    {
        if (items.Count == 0) return;
        Item currentItem = items[1];
        if (items.Count == 1)
        {
            currentItem = items[0];
        }
        if (Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.uses) != null)
        {
            items[1].sprite = Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.uses);
        }
        
    }
}
