using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InventoryManager : MonoBehaviour
{

    public Image ImagePrevious; // previous item
    public Image ImageCurrent; // current item
    public Image ImageNext; // next item

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
            Use(items[1]);
        }
    }

    void UpdateImages()//updating the images, checks the sprites available
    {
        Debug.Log("update");
        if (items.Count > 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[1].sprite;
            ImageNext.sprite = items[2].sprite;
        }
        else if (items.Count == 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[1].sprite;
            ImageNext.sprite = items[0].sprite;
        }
        else if(items.Count == 1)
        {
            ImagePrevious.sprite = items[0].sprite;
            ImageCurrent.sprite = items[0].sprite;
            ImageNext.sprite = items[0].sprite;
        }
    }

    void Use(item currentItem) //using the items, exceptions are: id 1 will not disappear after using all of its uses, id 3 is infinite
    {
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
        
    }
    void UpdateSprite(item Item)//Updates the sprite of an item
    {
        if (Resources.Load<Sprite>("IMG/" + Item.id + Item.uses )!= null)
            {
            Item.sprite = Resources.Load<Sprite>("IMG/" + Item.id + Item.uses);
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
