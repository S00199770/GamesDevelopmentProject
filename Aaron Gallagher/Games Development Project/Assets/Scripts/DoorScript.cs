using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    SpriteRenderer closedDoorSprite;
    public Sprite openDoorSprite;
     

    private void Start()
    {
        closedDoorSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //when door collides with player
        {
            closedDoorSprite.sprite = openDoorSprite; //use open door sprite
        }
    }
}
