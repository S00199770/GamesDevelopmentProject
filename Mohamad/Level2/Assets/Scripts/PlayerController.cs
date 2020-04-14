using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseMovementSpeed = 1.0f;
    public float movementSpeed = 100f;
    Vector3 movementDirection;
    float h;
    float v;

    Rigidbody2D bdy;


    void Start()
    {
        bdy = GetComponent<Rigidbody2D>();     
    }

    
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        movementDirection = new Vector3(h, v, 0);
        Movement();
    }

    void Movement() //Player movement
    {
        bdy.velocity = transform.position + (movementDirection * movementSpeed) * Time.deltaTime;
    }
}
