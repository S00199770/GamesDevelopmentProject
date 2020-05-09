using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow; //player to follow

    public float speed = 5.0f; //speed for the camera to close the distance between it and the player

    void Update()
    {
        float interpolation = speed * Time.deltaTime; //make it smooth so frame rate wont affect camera speed

        Vector3 position = this.transform.position;
        //Lerp gets the two positions and gradually closes the distance between the two positions
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
    }
}
