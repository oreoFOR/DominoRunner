using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Roll()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.forward * speed);
        print("adding");
    }
    private void FixedUpdate()
    {
        //rb.velocity = 
    }
}
