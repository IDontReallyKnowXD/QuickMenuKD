using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class Events : MonoBehaviour
{
    public List<item> items;
    public void Use()
    {
        currentItem = items[0]
        if (currentItem.id == 3 || (currentItem.id == 0 && currentItem.uses == 1))//if unlimited uses or syringe with no uses
        {
            return;
        }
        currentItem.uses--;
        if (currentItem.uses == 0)
        {
            items.RemoveAt(1);
        }
        UpdateSprite(currentItem);
        UpdateImages();
        UpdateImages();
    }
    
    public void SwipeRight() //1,2,3 -> 3,1,2
    {
        items.Insert(0, items[items.Count - 1]);
        items.RemoveAt(items.Count - 1);
        UpdateImages();
    }

    public void SwipeLeft() //1,2,3 -> 2,3,1
    {
        items.Add(items[0]);
        items.RemoveAt(0);
        UpdateImages();
    }
}
