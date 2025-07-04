using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class SwipeLeftQM : MonoBehaviour
{
    public ItemsList items;

    public UnityEvent updateImages;

    public void SwipeLeft() //1,2,3 -> 2,3,1
    {
        items.items.Add(items.items[0]);
        items.items.RemoveAt(0);
        updateImages.Invoke();
    }
}
