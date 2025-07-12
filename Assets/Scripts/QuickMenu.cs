using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class QuickMenu : MonoBehaviour
{

    public Image ImagePrevious; 
    public Image ImageCurrent;
    public Image ImageNext; 
    public Text TextPrevious;
    public Text TextCurrent;
    public Text TextNext;

    public void UpdateImages(List<ItemQuickMenu> items) //checks for important inputs each frame
    {

        if (items.Count > 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
            ImageCurrent.sprite = items[1].sprite;
            TextCurrent.text = items[1].Amount.ToString();
            ImageNext.sprite = items[2].sprite;
            TextNext.text = items[2].Amount.ToString();
        }

        else if (items.Count == 2)
        {
            ImagePrevious.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
            ImageCurrent.sprite = items[1].sprite;
            TextCurrent.text = items[1].Amount.ToString();
            ImageNext.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
        }

        else if (items.Count == 1)
        {
            ImagePrevious.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
            ImageCurrent.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
            ImageNext.sprite = items[0].sprite;
            TextPrevious.text = items[0].Amount.ToString();
        }
    }
}

