using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public List<int> items = new List<int>();
    public List<int> uses = new List<int>();

    public Image ImageP; // previous item
    public Image ImageC; // current item
    public Image ImageN; // next item

    private List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
        items.Add(0);
        uses.Add(3);
        items.Add(1);
        uses.Add(1);
        items.Add(2);
        uses.Add(1);
        items.Add(3);
        uses.Add(-1);
        //will be updated in another place where items can be added to the quick menu

        for (int i = 0; i < items.Count; i++)
        {
            Sprite s = Resources.Load<Sprite>("IMG/" + i);
            sprites.Add(s);
        }

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
            ImageP.sprite = sprites[items[0]];
            ImageC.sprite = sprites[items[1]];
            ImageN.sprite = sprites[items[2]];
        }
        else if (items.Count == 2)
        {
            ImageP.sprite = sprites[items[0]];
            ImageC.sprite = sprites[items[1]];
            ImageN.sprite = sprites[items[0]];
        }
        else
        {
            ImageP.sprite = sprites[items[0]];
            ImageC.sprite = sprites[items[0]];
            ImageN.sprite = sprites[items[0]];
        }

    }
    void Use()
    {
        if (items[1] != 0 || uses[items[1]] < 0)
        {
            uses[items[1]] = uses[items[1]] - 1;
        }

        else if (uses[items[1]] > 0)
        {
            if (uses[items[1]] != 1)
            {
                uses[items[1]] = uses[items[1]] - 1;
            }
        }

        if (uses[items[1]] == 0)
        {
            items.RemoveAt(1);
        }

        else if (uses[items[1]] > 0)
        {
            Sprite s = Resources.Load<Sprite>("IMG/" + items[1] + uses[items[1]]);
            sprites.RemoveAt(items[1]);
            sprites.Insert(items[1], s);
        }

        UpdateImages();
    }
}