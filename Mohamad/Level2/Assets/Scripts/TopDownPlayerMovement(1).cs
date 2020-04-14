using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 direction;
    float h, v;
    Rigidbody2D body;

    public float movementSpeed = 4;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
         ****Rotate to Face a Position***
         * 1. (Target) - Get the position of where you want to rotate to/look at/point towards
         * 2. (Direction) - Subtract our position from the target position to get the direction between us and the target
         * 3. (Rotate) - Set the "forward direction" (transform.up) of our object to the new direction
         */

        //Note there are multiple spaces (Local, World, View, Projection) and multiple transformations to move between spaces
        //ScreenToWorldPoint transforms the mouse position from 2D screen space (projection space) to a 3D (world space) position.

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//replace Input.mousePosition with any position

        direction = targetPosition - transform.position;//Step 2.
        direction.z = 0;//no need for Z axis in a 2D space, removing this will rotate the object in 3D space

        transform.up = direction;//Step 3.

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
