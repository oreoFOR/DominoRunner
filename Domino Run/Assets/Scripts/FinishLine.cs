using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Domino"))
        {
            manager.PassLevel();
        }
    }
}
