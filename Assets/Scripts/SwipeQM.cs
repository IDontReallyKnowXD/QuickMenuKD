using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class SwipeQM : MonoBehaviour
{
    public List<Item> items;
    
    public void SwipeRight() //1,2,3 -> 3,1,2
    {
        items.Insert(0, items[items.Count - 1]);
        items.RemoveAt(items.Count - 1);
    }

    public void SwipeLeft() //1,2,3 -> 2,3,1
    {
        items.Add(items[0]);
        items.RemoveAt(0);
    }
}
