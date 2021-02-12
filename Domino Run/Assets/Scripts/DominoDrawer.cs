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
    //transforms
    Transform lastDomino;
    Transform currentDomino;
    //custom
    Domino firstDomino;
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
            PlaceDominoes();
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
        if(lastDomino != null)
        {
            lastDomino.LookAt(currentDomino);
            lastDomino.GetComponent<Domino>().nextDomino = currentDomino.GetComponent<Domino>();
        }
        else
        {
            firstDomino = currentDomino.GetComponent<Domino>();
        }
    }
    void PlaceDominoes()
    {
        if(currentDomino != null)
        {
            float dominoNum = Mathf.Round(dist / dominoDist);
            Vector3 startpos = currentDomino.position;
            for (int i = 0; i < dominoNum; i++)
            {
                startpos += (transform.position - currentDomino.position).normalized * dominoDist;
                SpawnDomino(startpos);
            }
        }
        else
        {
            SpawnDomino(transform.position);
        }
    }
}
