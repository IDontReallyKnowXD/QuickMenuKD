using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class UseItemQM : MonoBehaviour
{
    public List<Item> items;
    public void Use()
    {
        if (items.Count == 0) return;
        Item currentItem = items[1];
        if (items.Count == 1)
        {
            currentItem = items[0];
        }
        currentItem = items[0];
        if (currentItem.id == 3 || (currentItem.id == 0 && currentItem.uses == 1))//if unlimited uses or syringe with no uses
        {
            return;
        }
        currentItem.uses--;
        if (currentItem.uses == 0)
        {
            items.RemoveAt(1);
        }

    }
}
