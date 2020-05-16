using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAttack : MonoBehaviour
{
    PlayerHealth playersHealth;
    PoliceHealth policeHealth;

    float damageCounter = 1;

    bool damageApplier = false;
    

    void Start()
    {
        playersHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        policeHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PoliceHealth>();
    }

    void Update()
    {
        if(damageCounter > 0)
        {
            damageCounter -= Time.deltaTime;
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy") //attack the player if the cop is not brainwashed
        {
            if (damageCounter <= 0)
            {
                playersHealth.ApplyDamage(10);
                
            }
            
        }
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag == "BrainWashed") //attack the other officers if the cop is brainwashed
        {
            if (damageCounter <= 0)
            {
                policeHealth.ApplyDamage(10);
                
            }    
        }
    }
}
