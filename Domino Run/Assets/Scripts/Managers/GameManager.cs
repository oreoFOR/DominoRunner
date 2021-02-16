using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelPassedPanel;
    public CinemachineVirtualCamera finishCam;
    public GemManager gemManager;
    public DominoManager dominoManager;
    public RunningDomino runner;
    public UiManager uiManager;
    public GameObject lostConfettis;
    public GameObject winConfettis;
    bool gameStarted;
    bool gameOver;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            StartGame();
        }
    }
    void StartGame()
    {
        runner.running = true;
        runner = null;
        uiManager.StartGame();
    }
    public void GameOver()
    {
        if (!gameOver)
        {
            gameOverPanel.SetActive(true);
            lostConfettis.SetActive(true);
            FailAndPass(false);
        }
    }
    public void PassLevel()
    {
        if (!gameOver)
        {
            levelPassedPanel.SetActive(true);
            finishCam.enabled = true;
            int levelNum = PlayerPrefs.GetInt("LevelNum");
            levelNum += 1;
            PlayerPrefs.SetInt("LevelNum", levelNum);
            winConfettis.SetActive(true);
            FailAndPass(true);
        }
    }
    void FailAndPass(bool success)
    {
        gameOver = true;
        gemManager.SaveGems();
        dominoManager.GameOver(success);
    }
}
