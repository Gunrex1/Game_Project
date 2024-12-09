using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {
        // Move the bullet to the left
        Vector2 pos = transform.position;
        pos.x -= bulletSpeed * Time.deltaTime; // Move left
        transform.position = pos;

        // Destroy the bullet if it goes off-screen
        Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.x < minPosition.x)
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}

