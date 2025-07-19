using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuickMenu : MonoBehaviour
{

    public Image ImagePrevious; 
    public Image ImageCurrent;
    public Image ImageNext; 

    public Text TextPrevious;
    public Text TextCurrent;
    public Text TextNext;

    public void UpdateImages(ItemQuickMenu itemPrevious, ItemQuickMenu itemCurrent, ItemQuickMenu itemNext)
    {


        ImagePrevious.sprite = itemPrevious.sprite;
        TextPrevious.text = itemPrevious.Amount.ToString();
        ImageCurrent.sprite = itemCurrent.sprite;
        TextCurrent.text = itemCurrent.Amount.ToString();
        ImageNext.sprite = itemNext.sprite;
        TextNext.text = itemNext.Amount.ToString();

    }
}

