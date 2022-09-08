using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        float inputMovement = Input.GetAxis("Vertical");
        
        Vector3 newPosition = new Vector3(
            transform.position.x,
            Mathf.Clamp(
                transform.position.y + (inputMovement * speed * Time.deltaTime),
                -4.25f,
                4.25f
            ),
            transform.position.z
        );
        
        transform.position = newPosition; 
    }
}
