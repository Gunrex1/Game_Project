using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Speed of the bullet
    public float bulletSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet upwards
        Vector2 pos = transform.position;
        pos.x += bulletSpeed * Time.deltaTime;
        transform.position = pos;

        // Destroy the bullet if it goes off-screen
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.x > maxPosition.x)
        {
            Destroy(gameObject);
        }

        
    }
}
