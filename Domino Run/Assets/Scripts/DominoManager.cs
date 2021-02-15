using Cinemachine;
using UnityEngine;

public class DominoManager : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    public CinemachineVirtualCamera vCam3;
    public Transform nextDomino;
    public GameObject runningDomino;
    bool cam1 = true;
    private void Start()
    {
        cam1 = true;
    }
    public void NextDomino()
    {
        Transform lastDomino = GetComponent<DominoDrawer>().finalDomino;
        print(lastDomino);
        nextDomino = Instantiate(runningDomino, lastDomino.position, Quaternion.identity).transform;
        AssignVars(lastDomino);
        vCam3.LookAt = nextDomino;
        vCam3.Follow = nextDomino;
        if (cam1)
        {
            vCam2.Follow = nextDomino;
            vCam2.LookAt = nextDomino;
            vCam2.enabled = true;
            cam1 = false;
            vCam1.Priority = 0;
            vCam2.Priority = 1;
        }
        else
        {
            vCam1.Follow = nextDomino;
            vCam1.LookAt = nextDomino;
            vCam1.enabled = true;
            cam1 = true;
            vCam1.Priority = 1;
            vCam2.Priority = 0;
        }
    }
    void AssignVars(Transform lastDomino)
    {
        //runnner
        nextDomino.GetComponent<DominoCollision>().manager = GetComponent<FollowMouse>();
        //lastDomino
        Domino lastDominoScr = lastDomino.GetComponent<Domino>();
        lastDominoScr.lastDomino = true;
        lastDominoScr.runner = nextDomino.GetComponent<DominoCollision>();
        lastDominoScr.StartRunner();
    }
}
