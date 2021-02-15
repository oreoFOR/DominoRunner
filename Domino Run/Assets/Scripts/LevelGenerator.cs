using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] obstacles;
    public GameObject[] gemFormations;
    public GameObject[] middleGemLines;
    public GameObject finishLine;
    int obstacleNum;
    public float obstacleDistMax;
    public float obstacleDistMin;
    public int maxObstacles;
    public int minObstacles;
    public float zPos;

    //
    //Gem stuff
    [Space]
    public GemManager gemManager;
    public RectTransform canvasRect;
    public RectTransform counterRect;
    private void Start()
    {
        obstacleNum = Random.Range(minObstacles, maxObstacles);
        for (int i = 0; i < obstacleNum; i++)
        {
            zPos += Random.Range(obstacleDistMin, obstacleDistMax);
            SpawnGems();
            int obstacle = Random.Range(0,obstacles.Length);
            Obstacle obstacleScr = Instantiate(obstacles[obstacle], new Vector3(0, 0, zPos),Quaternion.identity).GetComponent<Obstacle>();
            SpawnObstacleGems(obstacle);
            obstacleScr.manager = gameManager;
        }
        zPos += obstacleDistMin;
        FinishLine line = Instantiate(finishLine, new Vector3(0, 0, zPos), Quaternion.identity).GetComponent<FinishLine>();
        line.manager = gameManager;
    }
    void SpawnGems()
    {
        GemPicker picker = Instantiate(middleGemLines[Random.Range(0, 3)], new Vector3(0,0,zPos - obstacleDistMax/2), Quaternion.identity).GetComponent<GemPicker>();
        picker.canvasRect = canvasRect;
        picker.counterRect = counterRect;
        picker.gemManager = gemManager;
    }
    void SpawnObstacleGems(int obstacle)
    {
        GemPicker picker = Instantiate(gemFormations[obstacle], new Vector3(0, 0, zPos), Quaternion.identity).GetComponent<GemPicker>();
        picker.canvasRect = canvasRect;
        picker.counterRect = counterRect;
        picker.gemManager = gemManager;
    }
}
