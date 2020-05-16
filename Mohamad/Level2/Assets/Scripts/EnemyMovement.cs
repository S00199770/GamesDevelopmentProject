using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyMovement : MonoBehaviour
{
    //the game object we are going to follow
    public GameObject ObjectToFollow;
    public float walkSpeed = 1.3f;
    public bool enemyHit = false; //this is to change targets from the player to an enenmy when brainwashed

    float counter = 0; //counter to kill brainwashed after 20 seconds

    //the position of where we are going to be
    Vector2 targetPosition;
    Rigidbody2D enemyBody;
    private Vector2 movement;
    public int minimumRange = 8;
    public int halfOfMinRange; //half of the minimumrange to prompt cop to walk towardas player, giving player time to run
    float runSpeed = 3.0f;
    public Animator animator;
    public bool isWalking; //booleans to determine the state of the cop, walking or running will give a boolean value for the animator
    public bool isRunning; //booleans to determine the state of the cop, walking or running will give a boolean value for the animator
    public Transform playerCharacter; //players position
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        halfOfMinRange = minimumRange / 2;
        animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player").transform;
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (enemyHit == true) //when hit by the bullet...
        {
            ObjectToFollow = GameObject.FindGameObjectWithTag("Enemy"); //change object to follow to enemy

            counter += Time.deltaTime;

            if (counter >= 20)
            {
                Destroy(gameObject);
            }
        }
        //get the position of the object we are following
        targetPosition = ObjectToFollow.transform.position - transform.position;
        //keeps the vector length set to 1
        targetPosition.Normalize();
        movement = targetPosition;

        //Setting animation parameter values to be the same as the floats produced by the input GetAxisRaw
        animator.SetBool("Walking", isWalking);
        animator.SetBool("Running", isRunning);

        FlipSprite();



    }
    void FixedUpdate()
    {
        //calling the method to move the enemy towards the player character
        SpeedIdentifier();

    }


    void moveCharacter(Vector2 direction, float variableSpeed) //method that moves the cop towards the player
    {
        enemyBody.MovePosition((Vector2)transform.position + (direction * variableSpeed * Time.deltaTime));
    }


    void FlipSprite() // this will "turn" the cop around depending on where the player is (left or right of cop)
    {
        if (playerCharacter.position.x < this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
        }
        else
        {
            this.spriteRenderer.flipX = false;
        }
    }


    void SpeedIdentifier() //to adjust whether the enemy runs or walks towards the player
    {
        if (Vector3.Distance(transform.position, ObjectToFollow.transform.position) <= halfOfMinRange) //line of code to run when the player is fairly close to cop (half of minimum range)
        {
            //Cop will "walk"
            isWalking = true;
            isRunning = false;
            moveCharacter(targetPosition, walkSpeed);
        }
        else if (Vector3.Distance(transform.position, ObjectToFollow.transform.position) > halfOfMinRange && (Vector3.Distance(transform.position, ObjectToFollow.transform.position) <= minimumRange)) //code to run when the player is greater than half of the minimum range from cop and still within range
        {
            //Cop will "run"
            isWalking = false;
            isRunning = true;
            moveCharacter(targetPosition, runSpeed);

        }
        else if (Vector3.Distance(transform.position, ObjectToFollow.transform.position) > minimumRange) // Code to run when player is no longer in range of cop
        {
            //Cop will return to idle
            isWalking = false;
            isRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHit = true;
            transform.gameObject.tag = ("BrainWashed");
        }
    }
}