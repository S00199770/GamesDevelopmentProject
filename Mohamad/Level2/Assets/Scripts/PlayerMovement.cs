using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    Vector3 MousePosition;
    Vector2 playerInput;

    float h, v;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;

        Vector3 direction = MousePosition - transform.position;
        direction.Normalize();

        transform.up = direction;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + playerInput * movementSpeed * Time.fixedDeltaTime);
    }
}
