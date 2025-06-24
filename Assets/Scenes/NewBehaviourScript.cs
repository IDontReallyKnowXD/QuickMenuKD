using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InventoryManager : MonoBehaviour
{

    public Image ImageP; // previous item
    public Image ImageC; // current item
    public Image ImageN; // next item

    public List<item> items = new List<item>();

    void Start()
    {
        UpdateImages();
    }

    void Update()//checks for important inputs each frame
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

    void UpdateImages()//updating the images, checks the sprites available
    {
        if (items.Count > 2) //always happens-problem
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

    void Use() //using the items, exceptions are: id 1 will not disappear after using all of its uses, id 3 is infinite
    {
        item currentItem = items[1];
        if (currentItem.id != 3)
        {
            if (currentItem.id != 0 || (currentItem.id == 0 && currentItem.uses > 1))
            {
                currentItem.uses--;
            }
            if (currentItem.uses == 0)
            {
                items.RemoveAt(1);
            }
            else if (currentItem.uses > 0 || ((currentItem.id == 0 && currentItem.uses > 1) || currentItem.id != 0))
            {
                currentItem.sprite = Resources.Load<Sprite>("IMG/" + currentItem.id + currentItem.uses);
            }
            UpdateImages();
        }
    }
}


[Serializable] //Can be configured outside of code
public class item
{
    public int id;
    public int uses;
    public Sprite sprite;
    [TextArea]
    public string comment;

}
