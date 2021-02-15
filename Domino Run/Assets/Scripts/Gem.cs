using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemPicker picker;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Domino") || other.gameObject.CompareTag("FallenDomino"))
        {
            print("domino collision");
            picker.CollectGem(transform.position);
            Destroy(gameObject);
        }
    }
}
