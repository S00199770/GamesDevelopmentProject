using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAttack : MonoBehaviour
{
    PlayerHealth playersHealth;
    PoliceHealth policeHealth;
    

    void Start()
    {
        playersHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        policeHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PoliceHealth>();
    }

    void Update()
    {

        
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy") //attack the player if the cop is not brainwashed
        {
            
            playersHealth.ApplyDamage(25);
            
        }
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag == "BrainWashed") //attack the other officers if the cop is brainwashed
        {
            
            policeHealth.ApplyDamage(25);
        }
    }
}
