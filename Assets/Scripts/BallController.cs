using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGoalEventArg : EventArgs
{
    public NumeroJugador jugador;

    public OnGoalEventArg(NumeroJugador jugador)
    {
        this.jugador = jugador;
    }
    
}

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;
    private float mSpeedX;
    private float mSpeedY;

    private Rigidbody2D mRb;

    // Evento
    public event EventHandler OnGoal;
    
    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mSpeedX = -initialSpeed;
        mSpeedY = 0f;
    }

    private void Update()
    {
        // x = x + z
        // x += z
        //transform.position += Vector3.right * -speed * Time.deltaTime; 
        mRb.velocity = new Vector2(mSpeedX, mSpeedY);
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Paddles"))
        {
            mSpeedX *= -1;

            mSpeedY = UnityEngine.Random.Range(-initialSpeed, initialSpeed);
        }else
        {
            mSpeedY *= -1;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*OnGoalEventArg data;
        if (mSpeedX < 0 )
        {
            data = new OnGoalEventArg( NumeroJugador.DOS);
        }else
        {
            data = new OnGoalEventArg(NumeroJugador.UNO);
        }*/
        Debug.Log(mSpeedX);
        OnGoalEventArg data = new OnGoalEventArg(
            mSpeedX < 0 ? NumeroJugador.DOS : NumeroJugador.UNO
        );
        
        // Sucede el evento OnGoal
        OnGoal?.Invoke(this, data);
    }

    public void ReInit()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        mSpeedX = 0f;
        mSpeedY = 0f;
    }

    public void ReStart()
    {
        mSpeedX = -initialSpeed;
    }
}
