using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberOfZombies; //store number of zombies here
    
    public Text healthTextBox;
    
    PlayerHealth playerHealth;
    Vector3 playerPosition;
    Vector3 camera;

    void Awake()
    {

        //do not remove
        DontDestroyOnLoad(this);
        
        // numberOfZombies = GameObject.FindGameObjectsWithTag("Zombie").Length;
        healthTextBox = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        healthTextBox.text = "Health: " + playerHealth.Health;
        camera = playerPosition;
    }

    /* public void RecordZombieDeath() //method to call when killing a zombie
    {
        if(true)
        {
            numberOfZombies--; // subtract from total number of zombies
        }
        
        if(numberOfZombies <= 0)
        {
            SceneManager.LoadScene("GameComplete");
        }
    } */
}
