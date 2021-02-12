using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelPassedPanel;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void PassLevel()
    {
        levelPassedPanel.SetActive(true);
    }
}
