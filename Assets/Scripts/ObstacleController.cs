using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed; // speed of obstacle movement
    public LayerMask behindPlatformLayer; // layer mask for the layer to use when behind platform

    private Rigidbody2D rb;
    private bool movingThroughPlatform;
    private int previousLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousLayer = gameObject.layer;
    }

    private void FixedUpdate()
    {
        if (!movingThroughPlatform)
        {
            // move obstacle forward
            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            // set obstacle layer to be behind platform layer
            gameObject.layer = behindPlatformLayer;

            // set flag to move obstacle behind platform
            movingThroughPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            // set obstacle layer back to previous layer
            gameObject.layer = previousLayer;

            // set flag to resume normal movement
            movingThroughPlatform = false;
        }
    }
}
