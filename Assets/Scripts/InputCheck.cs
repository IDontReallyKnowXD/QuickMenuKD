using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputCheck : MonoBehaviour
{
    public UnityEvent swipeRight;
    public UnityEvent swipeLeft;
    public UnityEvent Use;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            swipeRight.Invoke(); // Calls all methods assigned in the Inspector
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            swipeLeft.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Use.Invoke();
        }
    }
}
