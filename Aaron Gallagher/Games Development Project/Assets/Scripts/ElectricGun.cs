using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricGun : MonoBehaviour
{
    public Transform bulletPosition;
    public GameObject bulletPrefab;

    public float energyCounter; //to charge up energy to shoot gun
    public int maxEnergy = 5; //to cap the energy
    public int energy; //current energy


    private void Start()
    {
        energy = maxEnergy;
    }

    void Update()
    {
        if (energy <= 0)
        {
            energyCounter += Time.deltaTime;
            if (energyCounter >= 8)
            {
                energy = maxEnergy;
                energyCounter = 0;
            }
        }

       if (Input.GetButtonDown("Fire1") && energy >= 1) //when left mouse is clicked
       {
            Shoot();
       }
    }

    void Shoot() //firing code
    {
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        energy--;
    }
}
