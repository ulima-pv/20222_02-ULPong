using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;
    private float mSpeedX;
    private float mSpeedY;

    private Rigidbody2D mRb;
    
    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mSpeedX = initialSpeed;
        mSpeedY = 0f;
    }

    private void Update()
    {
        // x = x + z
        // x += z
        //transform.position += Vector3.right * -speed * Time.deltaTime; 
        mRb.velocity = new Vector2(-mSpeedX, mSpeedY);
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Hay colision");
        mSpeedX *= -1;

        mSpeedY = Random.Range(-initialSpeed, initialSpeed);

    }
}
