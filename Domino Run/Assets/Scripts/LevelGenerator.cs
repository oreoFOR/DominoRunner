using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] obstacles;
    public GameObject finishLine;
    int obstacleNum;
    public float obstacleDistMax;
    public float obstacleDistMin;
    public int maxObstacles;
    public int minObstacles;
    public float zPos;
    private void Start()
    {
        obstacleNum = Random.Range(minObstacles, maxObstacles);
        for (int i = 0; i < obstacleNum; i++)
        {
            zPos += Random.Range(obstacleDistMin, obstacleDistMax);
            int obstacle = Random.Range(0,obstacles.Length);
            Obstacle obstacleScr = Instantiate(obstacles[obstacle], new Vector3(0, 0, zPos),Quaternion.identity).GetComponent<Obstacle>();
            obstacleScr.manager = gameManager;
        }
        zPos += obstacleDistMin;
        FinishLine line = Instantiate(finishLine, new Vector3(0, 0, zPos), Quaternion.identity).GetComponent<FinishLine>();
        line.manager = gameManager;
    }
}
