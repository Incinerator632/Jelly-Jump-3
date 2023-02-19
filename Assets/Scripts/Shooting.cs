using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // The projectile to be fired
    public Transform firePoint; // The point from which the projectile will be fired
    public float bulletForce = 20f; // The speed of the projectile
    public float fireRate = 0.5f; // The time delay between shots
    private float nextFire = 0.0f; // The time of the next shot

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Time.time > nextFire)
        { // Check if the player taps the screen with one finger and enough time has passed since the last shot
            nextFire = Time.time + fireRate; // Set the time of the next shot
            Shoot(); // Call the Shoot function
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Create a new projectile
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the projectile
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // Add force to the projectile to make it move in the direction of the firePoint
        StartCoroutine(DestroyBulletAfterTime(bullet)); // Destroy the projectile after a certain amount of time
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds
        Destroy(bullet); // Destroy the projectile
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        { // Check if the projectile hits an object with the "Obstacle" tag
            Destroy(collision.gameObject); // Destroy the obstacle
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
