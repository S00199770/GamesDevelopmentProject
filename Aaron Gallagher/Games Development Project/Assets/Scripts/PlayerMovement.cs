using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;

    Vector2 mousePosition;

    float h, v;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition.x = Input.GetAxisRaw("Horizontal");
        mousePosition.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + mousePosition * movementSpeed * Time.fixedDeltaTime);
    }
}
