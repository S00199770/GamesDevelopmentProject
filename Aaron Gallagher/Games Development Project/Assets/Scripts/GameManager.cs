using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int heldKeys = 0;

    public Text healthTextBox;
    //PlayerHealth playerHealth;

    private void Start()
    {

    }

    void Awake()
    {
        //do not remove
        DontDestroyOnLoad(this);
       //healthTextBox = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
       // playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        //healthTextBox.text = "Health: " + playerHealth.Health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            heldKeys += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("LockedDoor2") && heldKeys >= 3)
        {
            SceneManager.LoadScene("GameComplete"); 
        }
    }
}
