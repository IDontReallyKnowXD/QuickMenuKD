using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Events;


public class QuickMenu : MonoBehaviour
{

    public Image ImagePrevious; 
    public Image ImageCurrent;
    public Image ImageNext; 

    public List<item> items = new List<item>();

    public UnityEvent SwipeRight;
    public UnityEvent SwipeLeft;
    public UnityEvent Use;


    void Start()
    {
        UpdateImages();
    }

    void Update() //checks for important inputs each frame
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
            Use(items[0]);
        }
    }

    void UpdateImages() //updating the images, checks the sprites available
    {
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

    void UpdateSprite(item Item) //Updates the sprite of an item
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
    public int BonusID;
    public int BonusAmount;
    public int Amount;
    public int MaxUses;
    [TextArea]
    public string comment;

}
