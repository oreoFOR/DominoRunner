using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public ParticleSystem[] confetties;
    public GameManager gameManager;
    public enum CollisionType
    {
        water,
        finish
    }
    public CollisionType type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (type == CollisionType.finish)
            {
                Win();
            }
            else if (type == CollisionType.water)
            {
                other.GetComponent<Rigidbody>().drag = 5;
                Die();
            }
        }
    }
    void Win()
    {
        for (int i = 0; i < confetties.Length; i++)
        {
            confetties[i].Play();
        }
        gameManager.PassLevel();
    }
    void Die()
    {
        for (int i = 0; i < confetties.Length; i++)
        {
            confetties[i].Play();
        }
        print("u lose");
        gameManager.GameOver();
    }
}
