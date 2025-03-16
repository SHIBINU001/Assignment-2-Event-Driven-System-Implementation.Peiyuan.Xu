using System.Collections;
using System.Collections.Generic;
using UnityEngine; //Peiyuan.Xu 000928128 Mohawk College Game Design 10009 Assignment 1

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }
}
