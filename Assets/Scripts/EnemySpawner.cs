using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 2f; // Time between spawns

    void Start()
    {
        // Start spawning enemies repeatedly
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

   void SpawnEnemy()
{
    // Get the screen bounds
    float screenHeight = Camera.main.orthographicSize;
    float spawnY = Random.Range(-screenHeight, screenHeight); // Random Y position within the vertical screen bounds

    // Spawn position (right side of the screen)
    Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.5f)); // Right edge of the screen (center vertically)
    spawnPosition.y = spawnY; // Assign random vertical position

    // Instantiate the enemy
    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
}

}
