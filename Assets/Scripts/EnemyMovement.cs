using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public AudioClip destructionSound; // Assign in Inspector
    private AudioSource audioSource;
    public float maxSpeed = 7f; // Movement speed
    public GameObject enemyBulletPrefab; // Drag and drop your EnemyBullet prefab here
    public float fireRate = 1.5f; // Time interval between shots
    public GameObject destructionAnimationPrefab; // Assign your destruction animation prefab here

    private float nextFireTime = 0f; // Timer to track when the enemy should fire next

    void Start()
    {
        // Rotate the enemy to face left
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    void Update()
    {
        // Move the enemy from right to left
        Vector2 pos = transform.position;
        pos.x -= maxSpeed * Time.deltaTime; // Move left
        transform.position = pos;

        // Destroy the enemy if it goes out of bounds
        Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Bottom-left corner
        if (transform.position.x < minPosition.x)
        {
            Destroy(gameObject); // Destroy the enemy once it's out of the screen
        }

        // Fire bullets
        if (Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate; // Schedule the next fire
        }
    }

    void FireBullet()
    {
        // Instantiate the bullet at the enemy's position
        Vector3 bulletSpawnPosition = transform.position + new Vector3(-1, 0, 0); // Adjust offset as needed
        Instantiate(enemyBulletPrefab, bulletSpawnPosition, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check collision with PlayerBullet
        if (other.CompareTag("PlayerBullet"))
        {
            if (destructionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(destructionSound);
            }

            // Trigger destruction animation
            if (destructionAnimationPrefab != null)
            {
                Instantiate(destructionAnimationPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // Destroy the enemy
            Destroy(other.gameObject); // Destroy the player's bullet
            Debug.Log("Enemy destroyed!");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(10); // Increment score
            }
        }
    }
}
