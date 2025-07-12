using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class QuickMenuManager : MonoBehaviour
{
    public List<ItemQuickMenu> items;

    public TransferQuickMenuList updateImages;

    public Boolean IsEmpty() 
    {
        if (items.Count == 0) return true;
        else return false;
    }

    public void SwipeLeft() //1,2,3 -> 2,3,1
    {
        if(IsEmpty())return;
        items.Add(items[0]);
        items.RemoveAt(0);
        updateImages.Invoke(items);
    }

    public void SwipeRight() //1,2,3 -> 3,1,2
    {
        if (IsEmpty()) return;
        items.Insert(0, items[items.Count - 1]);
        items.RemoveAt(items.Count - 1);
        updateImages.Invoke(items);
    }

    public void Use()
    {
        if (IsEmpty()) return;
        ItemQuickMenu currentItem = items[1];
        if (items.Count == 1)
        {
            currentItem = items[0];
        }
        if (currentItem.id == 3 || (currentItem.id == 0 && currentItem.uses == 1))//if unlimited uses or syringe with no uses
        {
            return;
        }
        currentItem.uses--;
        if (currentItem.uses < 1)
        {
            if (currentItem.Amount > 1)
            {
                currentItem.Amount--;
                currentItem.uses = currentItem.MaxUses;
                UpdateSprites(currentItem);
                return;
            }
            else if (items.Count > 1)
            {
                items.RemoveAt(1);
                updateImages.Invoke(items);
                return;
            }
            else
            {
                items.RemoveAt(0);
                updateImages.Invoke(items);
                return;
            }
        }
        UpdateSprites(currentItem);

    }

    public void UpdateSprites(ItemQuickMenu currentItem)
    {
        if (Resources.Load<Sprite>("IMG/" + currentItem.id +  currentItem.id + currentItem.uses) != null)
        {
            if (items.Count > 1)
            {
                items[1].sprite = Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.id + currentItem.uses);
                updateImages.Invoke(items);
                return;
            }
            else
            {
                items[0].sprite = Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.id + currentItem.uses);
                updateImages.Invoke(items);
                return;
            }
        }

    }
}
[Serializable]
public class TransferQuickMenuList : UnityEvent<List<ItemQuickMenu>> { }