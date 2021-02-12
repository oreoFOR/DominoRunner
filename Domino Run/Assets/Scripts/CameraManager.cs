using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;

    public void NextDomino(Transform nextDomino)
    {
        vCam.Follow = nextDomino;
        vCam.LookAt = nextDomino;
    }
}
