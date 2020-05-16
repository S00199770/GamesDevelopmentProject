using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text healthTextBox;
    public Text policeBrainwashedCounter;
    public Text policeNumberLeft;
    public int policeLeft;
    public int brainwashedLeft;
    PlayerHealth playerHealth;

    void Awake()
    {
        //do not remove
        DontDestroyOnLoad(this);
        healthTextBox = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        policeBrainwashedCounter = GameObject.FindGameObjectWithTag("BrainWashedText").GetComponent<Text>();
        policeNumberLeft = GameObject.FindGameObjectWithTag("PoliceLeftText").GetComponent<Text>();

        //number of gameobjects
        brainwashedLeft = GameObject.FindGameObjectsWithTag("BrainWashed").Length;
        policeLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        healthTextBox.text = "Health: " + playerHealth.Health;
        policeBrainwashedCounter.text = "Police Brainwashed: " + brainwashedLeft;
        policeNumberLeft.text = "Police Left: " + policeLeft;
    }

}
