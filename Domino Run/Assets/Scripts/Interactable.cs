using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Domino"))
        {
            Domino otherDomino = collision.gameObject.GetComponentInParent<Domino>();
            if (otherDomino.state == Domino.State.falling)
            {
                Interact();
            }
        }
    }
    public void Interact()
    {
        anim.SetTrigger("fall");
    }
}
