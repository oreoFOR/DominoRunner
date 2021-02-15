using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorImage : MonoBehaviour
{
    FollowMouse mouse;
    public Transform cursorImage;
    public Camera cam;
    private void Start()
    {
        mouse = GetComponent<FollowMouse>();
    }
    private void Update()
    {
        if (mouse.followMouse)
        {
            //Vector2 mousePos = cam.ViewportToWorldPoint(Input.mousePosition);
            cursorImage.position = Input.mousePosition;
        }
    }
    public void EnableCursor(bool state)
    {
        cursorImage.position = Input.mousePosition;
        cursorImage.gameObject.SetActive(state);
    }
}
