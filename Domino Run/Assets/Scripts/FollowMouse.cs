using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public DominoDrawer drawer;
    public RollingBall ball;
    public Camera cam;
    bool followMouse;
    public LayerMask groundMask;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            followMouse = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            followMouse = false;
            drawer.Knock();
            //ball.Roll();
        }
        if (followMouse)
        {
            FollowMouseLogic();
        }
    }
    void FollowMouseLogic()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500,groundMask))
        {
            transform.position = hit.point;
        }
    }
}
