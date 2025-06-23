using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public class item
    {
        public int id;
        public int uses;
        public Sprite sprite;

        public item(int id, int uses)
        {
            this.id = id;
            this.uses = uses;
            this.sprite = Resources.Load<Sprite>("IMG/" + id);
        }

        public void UpdateSprite()
        {
            sprite = Resources.Load<Sprite>("IMG/" + id + uses);
        }
    }

    public Image ImageP; // previous item
    public Image ImageC; // current item
    public Image ImageN; // next item

    private List<item> items = new List<item>();

    void Start()
    {
        items.Add(new item(0, 3));
        items.Add(new item(1, 1));
        items.Add(new item(2, 1));
        items.Add(new item(3, -1)); // infinite uses

        UpdateImages();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            items.Add(items[0]);
            items.RemoveAt(0);
            UpdateImages();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            items.Insert(0, items[items.Count - 1]);
            items.RemoveAt(items.Count - 1);
            UpdateImages();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    void UpdateImages()
    {
        if (items.Count > 2)
        {
            ImageP.sprite = items[0].sprite;
            ImageC.sprite = items[1].sprite;
            ImageN.sprite = items[2].sprite;
        }
        else if (items.Count == 2)
        {
            ImageP.sprite = items[0].sprite;
            ImageC.sprite = items[1].sprite;
            ImageN.sprite = items[0].sprite;
        }
        else
        {
            ImageP.sprite = items[0].sprite;
            ImageC.sprite = items[0].sprite;
            ImageN.sprite = items[0].sprite;
        }
    }

    void Use()
    {
        if (items.Count < 2) return;

        item currentItem = items[1];

        if (currentItem.uses != 0)
        {
            if (currentItem.uses > 0)
                currentItem.uses--;

            if (currentItem.uses == 0)
            {
                items.RemoveAt(1);
            }
            else if (currentItem.uses > 0)
            {
                currentItem.UpdateSprite();
            }
        }

        UpdateImages();
    }
}
