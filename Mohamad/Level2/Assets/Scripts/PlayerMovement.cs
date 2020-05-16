using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    Vector3 MousePosition;
    float x, y;
    public Animator animator;
    Vector2 direction;
    Rigidbody2D body;
    SpriteRenderer playerSprite;
    Collider2D collider;
    Transform transformRotation;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        transformRotation = GetComponent<Transform>();
        
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");


        direction = new Vector3(x, y);
        direction.Normalize();
        
        transform.up = direction;

        //Setting animation parameter values to be the same as the floats produced by the input GetAxisRaw
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        FixSpritePositioning();
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + (direction * movementSpeed * Time.fixedDeltaTime));
    }

    void FixSpritePositioning()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            playerSprite.flipY = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerSprite.flipY = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprite.flipX = true;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerSprite.flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerSprite.flipY = false;
        }
    }
}
