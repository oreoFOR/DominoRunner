using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Domino"))
        {
            if(collision.gameObject.GetComponent<Rigidbody>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            else
            {
                Domino domino = collision.gameObject.GetComponentInParent<Domino>();
                domino.nextDomino = null;
                domino.gameObject.AddComponent<Rigidbody>();
            }
            manager.GameOver();
        }
    }
}
