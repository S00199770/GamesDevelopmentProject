using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerHealth : HealthComponent
{
    

    private void Start()
    {

    }
    private void Update()
    {
        if(Health <= 0)
        {
            KillCharacter();
        }
    }
    public override void KillCharacter()
    {
        base.KillCharacter();
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* if(collision.gameObject.CompareTag("Zombie"))
        {
            ApplyDamage(10);
            
        } */
    }

}
