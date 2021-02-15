using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelPassedPanel;
    public CinemachineVirtualCamera finishCam;
    public GemManager gemManager;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gemManager.SaveGems();
    }
    public void PassLevel(RunningDomino domino)
    {
        levelPassedPanel.SetActive(true);
        finishCam.enabled = true;
        domino.speed = 0;
        gemManager.SaveGems();
    }
}
