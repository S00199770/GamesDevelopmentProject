using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 direction;
    public float h, v;
    Rigidbody2D body;

    public float movementSpeed = 400;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        /* 
         * Movement is relative to the world (up/down is always going to move on the Y Axis, left/right is always going to move on the X Axis 
         * 1. Mulitply our h and v values by movementSpeed
         * 2. Add the result of step 1 to our current position
         * 3. Set the position of the RigidBody2D to this new location (teleporting our object a very short distance to move)
         */

        body.MovePosition(transform.position + (new Vector3(h, v, 0) * movementSpeed) * Time.deltaTime);
    }
}

