using UnityEngine;
using UnityEngine.Events;

public class InputCheck : MonoBehaviour
{
    public UnityEvent swipeRight;
    public UnityEvent swipeLeft;
    public UnityEvent Use;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            swipeRight.Invoke(); 
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
