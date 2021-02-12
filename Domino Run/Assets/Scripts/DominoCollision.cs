using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public RunningDomino runner;
    private void Start()
    {
        runner = GetComponent<RunningDomino>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Domino"))
        {
            collision.gameObject.GetComponentInParent<Domino>().Knock();
            runner.running = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
