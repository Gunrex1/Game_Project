using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{      
     public AudioClip collisionSound;
    private AudioSource audioSource;

    public float maxSpeed = 7f;
    public float playerBoundaryRadius = 0.5f;
    public GameObject playerBulletPrefab;
public GameManager gameManager;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        Vector2 pos = transform.position;
        pos.x += moveX;
        pos.y += moveY;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        pos.x = Mathf.Clamp(pos.x, -widthOrtho + playerBoundaryRadius, widthOrtho - playerBoundaryRadius);
        pos.y = Mathf.Clamp(pos.y, -Camera.main.orthographicSize + playerBoundaryRadius, Camera.main.orthographicSize - playerBoundaryRadius);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Vector3 bulletSpawnPosition = transform.position + new Vector3(0, 0, 0);
        Instantiate(playerBulletPrefab, bulletSpawnPosition, Quaternion.identity);
    }

  void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("EnemyBullet"))
    {
        if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        Destroy(gameObject); // Destroy the player
        Destroy(other.gameObject); // Destroy the enemy bullet
        Debug.Log("Player hit by enemy bullet!");
        gameManager.EndGame(); // Call GameManager to end the game
    }
}

}
