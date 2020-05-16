using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBolt : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D bulletBody;

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = (mousePosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulletCollision(collision);
    }

    void bulletCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("PhysicalDecor") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
