using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoDrawer : MonoBehaviour
{
    //floats
    public float dominoDist;
    float dist;
    //vectors
    Vector3 lastPos;
    //game objects
    public GameObject dominoPrefab;
    public GameObject errorPrefab;
    //transforms
    Transform lastDomino;
    Transform currentDomino;
    public Transform finalDomino;
    //custom
    Domino firstDomino;
    public FollowMouse follower;
    //bool
    public bool dropOnRelease = true;
    private void Update()
    {
        float frameDist = (transform.position - lastPos).magnitude;
        //
        if(currentDomino != null)
        {
            dist = (transform.position - currentDomino.position).magnitude;
        }
        else
        {
            dist += frameDist;
        }
        lastPos = transform.position;
        if(dist >= dominoDist)
        {
            print("distance crossed");
            PlaceDominoes(Vector3.zero);
        }
    }
    public void Knock()
    {
        if (dropOnRelease)
        {
            SpawnDomino(transform.position);
            currentDomino.rotation = Quaternion.LookRotation(currentDomino.position - lastDomino.position);
            firstDomino.Knock();
        }
        finalDomino = currentDomino;
        currentDomino = null;
        lastDomino = null;
    }
    void SpawnDomino(Vector3 spawnPos)
    {
        if(currentDomino != null)
        {
            lastDomino = currentDomino;
        }
        dist = 0;
        currentDomino = Instantiate(dominoPrefab, spawnPos, Quaternion.identity).transform;
        currentDomino.GetComponent<Domino>().line = follower.currentLine;
        if(lastDomino != null)
        {
            lastDomino.LookAt(currentDomino);
            lastDomino.GetComponent<Domino>().nextDomino = currentDomino.GetComponent<Domino>();
            lastDomino.GetComponent<Domino>().Fall();
        }
        else
        {
            firstDomino = currentDomino.GetComponent<Domino>();
        }
    }
    public void PlaceDominoes(Vector3 startPos)
    {
        if(startPos == Vector3.zero)
        {
            if (currentDomino != null)
            {
                startPos = currentDomino.position;
                float dominoNum = Mathf.Round(dist / dominoDist);
                for (int i = 0; i < dominoNum; i++)
                {
                    startPos += (transform.position - currentDomino.position).normalized * dominoDist;
                    SpawnDomino(startPos);
                }
            }
            else
            {
                print("first this");
                SpawnDomino(transform.position);
            }
        }
        else
        {
            float runDist = (startPos - transform.position).magnitude;
            float dominoNum = Mathf.Round(runDist/ dominoDist);
            print(dominoNum);
            for (int i = 0; i < dominoNum; i++)
            {
                if(i > 0)
                {
                    startPos += (transform.position - currentDomino.position).normalized * dominoDist;
                }
                SpawnDomino(startPos);
            }
        }
    }
    
}
