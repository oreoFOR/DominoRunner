﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public RunningDomino runner;
    public FollowMouse manager;
    public bool firstDomino;
    public GemPicker gemPicker;
    private void Start()
    {
        if (firstDomino)
        {
            StartMoving();
        }
    }
    public void StartMoving()
    {
        runner.speed = 10;
        GetComponent<Animator>().SetTrigger("standUp");
        Invoke("SetUp", 0.75f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Domino"))
        {
            Domino otherDomino = collision.gameObject.GetComponentInParent<Domino>();
            if (otherDomino.state == Domino.State.standing)
            {
                otherDomino.Knock();
                runner.running = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CameraSetup(otherDomino);
            }
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            gemPicker.CollectGem(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
        }
    }
    void SetUp()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void CameraSetup(Domino hitDomino)
    {
        manager.SwitchCams(hitDomino);
        Destroy(gameObject);
    }
}
