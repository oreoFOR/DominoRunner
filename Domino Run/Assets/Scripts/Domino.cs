using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    Animator anim;
    public Domino nextDomino;
    public bool lastDomino;
    public DominoCollision runner;
    public DominoLine line;
    public GameObject col;
    bool fallen;
    bool startedRunner;
    public enum State
    {
        standing,
        falling
    }
    public State state;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Knock()
    {
        fallen = true;
        anim.SetTrigger("fall");
        state = State.falling;
        gameObject.tag = "FallenDomino";
        col.tag = "FallenDomino";
        StartCoroutine(KnockNext());
        if (lastDomino)
        {
            StartRunner();
        }
    }
    IEnumerator KnockNext()
    {
        yield return new WaitForSeconds(0.075f);
        if (nextDomino != null)
        {
            nextDomino.Knock();
        }
    }
    public void StartRunner()
    {
        if(!startedRunner && fallen)
        runner.StartMoving();
    }
    public void Fall()
    {
        if (fallen)
        {
            StartCoroutine(KnockNext());
        }
    }
}
