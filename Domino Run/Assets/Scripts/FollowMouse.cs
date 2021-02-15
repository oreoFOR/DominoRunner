using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public DominoDrawer drawer;
    public RollingBall ball;
    public Camera cam;
    public bool followMouse;
    public LayerMask groundMask;
    public bool finishedPlacing;
    bool switchCams;
    public GameObject dominoLine;
    public DominoLine currentLine;
    public CursorImage cursorImage;
    public DominoManager dominoManager;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(dominoLine).GetComponent<DominoLine>();
            followMouse = true;
            switchCams = false;
            finishedPlacing = false;
            cursorImage.EnableCursor(true);
            FollowMouseLogic();
            drawer.PlaceDominoes(dominoManager.nextDomino.position);
            print(dominoManager.nextDomino.position);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            currentLine.finishedLine = true;
            finishedPlacing = true;
            followMouse = false;
            cursorImage.EnableCursor(false);
            drawer.Knock();
            currentLine.finalDomino = drawer.finalDomino;
            if (switchCams)
            {
                switchCams = false;
                finishedPlacing = false;
                dominoManager.NextDomino();
            }
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
    public void SwitchCams(Domino hitDomino)
    {
        if (hitDomino.line.finishedLine)
        {
            switchCams = false;
            finishedPlacing = false;
            drawer.finalDomino = hitDomino.line.finalDomino;
            dominoManager.NextDomino();
        }
        else
        {
            switchCams = true;
        }
    }
}
