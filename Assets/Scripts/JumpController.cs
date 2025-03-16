using System.Collections;
using System.Collections.Generic;
using UnityEngine;    // Peiyuan.Xu 000928128 Mohawk Game Design 10009 Assignment 1


public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;


    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
