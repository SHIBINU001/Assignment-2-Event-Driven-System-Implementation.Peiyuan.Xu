using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;    // Peiyuan.Xu 000928128 Mohawk Game Design 10009 Assignment 1

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] int speed;
    float speedMultiplier;
    
    [Range(1,10)]
    [SerializeField] float acceleration;
   


    bool bthPressed;

    bool isWallTouch;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;
    public bool speedBoostActive;
    public CoinManager cm;


    Vector2 relativeTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        UpdateRelativeTransform();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMultiplier();
        float targetSpeed = speed * speedMultiplier*relativeTransform.x;

        rb.velocity = new Vector2 (targetSpeed, rb.velocity.y);
        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.06f, 0.8f), 0, wallLayer);
        
        if (isWallTouch ) 
        {
            Flip();
        }
    
    }

    public void Flip()

    {
        transform.Rotate(0, 180, 0);
        UpdateRelativeTransform();
    }

    void UpdateRelativeTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }



    public void Move(InputAction.CallbackContext value)
    {
     if (value.started)
        {
          bthPressed= true;
           
        }
     else if (value.canceled)
        {
           bthPressed = false;
            
        }
    }

    void UpdateSpeedMultiplier()
    {
       if (bthPressed && speedMultiplier <1)
        {
            speedMultiplier += Time.deltaTime*acceleration;
        }
       else if (!bthPressed && speedMultiplier >0) 
        {
            speedMultiplier -= Time.deltaTime*acceleration;
        if (speedMultiplier <0) speedMultiplier = 0;
        }
    }

    public void ActiveSpeedBoost()
    {
        if (!speedBoostActive)
        {
            speedBoostActive = true;
            speed += 5;
            StartCoroutine(SpeedBoostTime());
        }
    }
    IEnumerator SpeedBoostTime()
    {
        yield return new WaitForSeconds(3);
        speedBoostActive = false;
        speed -= 5;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
