using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAttack : MonoBehaviour
{
    PlayerHealth playersHealth;
    PoliceHealth policeHealth;


    void Start()
    {
        playersHealth = new PlayerHealth();
        policeHealth = new PoliceHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
