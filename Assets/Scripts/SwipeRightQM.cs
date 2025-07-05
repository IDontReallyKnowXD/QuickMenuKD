using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class SwipeRightQM : MonoBehaviour
{
    public ItemsList items;

    public UnityEvent updateImages;

    public void SwipeRight() //1,2,3 -> 3,1,2
    {
        if (items.items.Count < 1) return;
        items.items.Insert(0, items.items[items.items.Count - 1]);
        items.items.RemoveAt(items.items.Count - 1);
        updateImages.Invoke();
    }
}
