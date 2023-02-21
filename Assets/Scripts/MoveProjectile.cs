using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 5.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }

        if (collision.gameObject.CompareTag("Projectile")) // Check if the projectile hits an object with the "Obstacle" tag
        {
            Destroy(collision.gameObject); // Destroy the obstacle
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
