using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDomino : MonoBehaviour
{
    public float speed;
    public bool running = true;
    Animator anim;
    Vector3 lastPos;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 changePos = (transform.position - lastPos)/ Time.deltaTime;
        lastPos = transform.position;
        anim.SetFloat("Blend", changePos.magnitude);
        if(running)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
