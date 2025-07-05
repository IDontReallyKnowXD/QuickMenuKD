using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class UseItemQM : MonoBehaviour //may need to get just the current ItemQM
{

    public ItemsList items;

    public UnityEvent updateSprites;

    public void Use()
    {
        if (items.items.Count == 0) return;
        ItemQM currentItem = items.items[1];
        if (items.items.Count == 1)
        {
            currentItem = items.items[0];
        }
        if (currentItem.id == 3 || (currentItem.id == 0 && currentItem.uses == 1))//if unlimited uses or syringe with no uses
        {
            return;
        }
        currentItem.uses--;
        if (currentItem.uses == 0)
        {
            if(currentItem.Amount > 1) 
            {
                currentItem.Amount--;
                currentItem.uses = currentItem.MaxUses;
                updateSprites.Invoke();
                return;
            }
            if (items.items.Count > 1)
            {
                items.items.RemoveAt(1);
            }
            else
            { 
                items.items.RemoveAt(0);
            }
        }
        updateSprites.Invoke();

    }
}
