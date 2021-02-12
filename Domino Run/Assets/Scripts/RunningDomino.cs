using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDomino : MonoBehaviour
{
    public float speed;
    public bool running = true;
    private void Update()
    {
        if(running)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
