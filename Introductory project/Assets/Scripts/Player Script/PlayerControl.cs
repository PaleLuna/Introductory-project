 using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool CatchTheTouch()
    {
        bool isTouch = false;
        if (Input.GetMouseButtonDown(0))
            isTouch = true;

        return isTouch;
    }
}
