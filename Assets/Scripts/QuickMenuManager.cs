using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

public class QuickMenuManager : MonoBehaviour
{
    public List<ItemQuickMenu> items;

    public TransferQuickMenuList updateImages;

    private bool UsingSyringe = false;

    private int itemIndex;

    public int syringeIndex;

    public Boolean IsEmpty()
    {
        if (items.Count == 0) return true;
        else return false;
    }

    public void SwipeLeft() //1,2,3 -> 2,3,1
    {
        if (IsEmpty()) return;
        items.Add(items[0]);
        items.RemoveAt(0);
        EventLogicUpdateImages();
    }

    public void SwipeRight() //1,2,3 -> 3,1,2
    {
        if (IsEmpty()) return;
        items.Insert(0, items[items.Count - 1]);
        items.RemoveAt(items.Count - 1);
        EventLogicUpdateImages();
    }

    public void Use()
    {
        if (IsEmpty()) return;
        ItemQuickMenu currentItem = items[1];
        itemIndex = 1;
        if (items.Count == 1)
        {
            currentItem = items[0];
            itemIndex = 0;
        }
        if (currentItem.Uses == -1)//if unlimited uses
        {
            return;
        }
        if (currentItem.Id == 10 && currentItem.Uses != 0)//if a syringe is used
        {
            UseSyringeAsync(currentItem, itemIndex);
            return;
        }
        else if (currentItem.Id == 10 && currentItem.Uses == 0)
        {
            return;
        }
        if (currentItem.Uses > 0)
        {
            currentItem.Uses--;
        }
        if (currentItem.Uses == 0 && currentItem.CanBeErased==true)
        {
            if (currentItem.Amount > 1)
            {
                currentItem.Amount--;
                currentItem.Uses = currentItem.MaxUses;
                UpdateSprites(currentItem);
                return;
            }     
            else
            {
                items.RemoveAt(itemIndex);
                EventLogicUpdateImages();
                return;
            }
        }
        UpdateSprites(currentItem);
    }

    public async Task UseSyringeAsync(ItemQuickMenu currentItem, int ItemIndex)
    {
        if (UsingSyringe == true) return;
        UsingSyringe = true;
        while (Input.GetKey(KeyCode.E) && items[ItemIndex].Id == 10)
        {
            currentItem.Uses--;
            currentItem.Amount--;
            if (currentItem.Uses == 0)
            {
                UpdateSprites(currentItem);
                return;
            }
            UpdateSprites(currentItem);
            await Task.Delay(150);
        }
        UsingSyringe = false;
    }

    public void UpdateSprites(ItemQuickMenu currentItem)
    {
        if (Resources.Load<Sprite>("IMG/" + currentItem.Id + currentItem.Uses) != null)
        {
            if (items.Count > 1)
            {
                items[1].sprite = Resources.Load<Sprite>("IMG/" + currentItem.Id + currentItem.Uses);
                EventLogicUpdateImages();
                return;
            }
        }
        EventLogicUpdateImages();
    }

    public void EventLogicUpdateImages()
    {
        if (items.Count > 2)
        {
            updateImages.Invoke(items[0], items[1], items[2]);
        }

        else if (items.Count == 2)
        {
            updateImages.Invoke(items[0], items[1], items[0]);
        }

        else if (items.Count == 1)
        {
            updateImages.Invoke(items[0], items[0], items[0]);
        }
    }

}

[Serializable]
public class TransferQuickMenuList : UnityEvent<ItemQuickMenu, ItemQuickMenu, ItemQuickMenu> { }