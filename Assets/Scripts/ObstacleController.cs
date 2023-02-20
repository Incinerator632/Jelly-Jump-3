using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public LayerMask platformLayer; // layer mask for the platform layer

    private Collider2D obstacleCollider;
    private bool isColliding;

    private void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (collision.gameObject.layer == platformLayer)
            {
                obstacleCollider.isTrigger = true;
                isColliding = true;
            }
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            if (other.gameObject.layer == platformLayer)
            {
                obstacleCollider.isTrigger = false;
                isColliding = false;
            }
        }
    }*/
}
