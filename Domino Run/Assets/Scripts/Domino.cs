using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    Animator anim;
    public Domino nextDomino;
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
        anim.SetTrigger("fall");
        state = State.falling;
        StartCoroutine(KnockNext());
    }
    IEnumerator KnockNext()
    {
        yield return new WaitForSeconds(0.075f);
        if(nextDomino != null)
        nextDomino.Knock();
    }
}
