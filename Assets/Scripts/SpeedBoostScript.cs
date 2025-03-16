using System.Collections;
using System.Collections.Generic;
using UnityEngine;    // Peiyuan.Xu 000928128 Mohawk College Game Design 10009 Assignment 1

public class SpeedBoostScript : MonoBehaviour
{
    private MovementController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.ActiveSpeedBoost();
            }
            Destroy(this.gameObject);
        }
    }
}