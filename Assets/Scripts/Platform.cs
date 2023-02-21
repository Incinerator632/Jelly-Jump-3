using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // Start is called before the first frame update
    public class Platform : MonoBehaviour
    {
        public float jumpForce = 10f;
        public int hitAmount_Max = 2;
        private int hitAmount_Current;
        public LayerMask projectileLayer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
            if (collision.relativeVelocity.y <= 0f)
            {
                Rigidbody2D player2Rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

                if (player2Rb2d != null)
                {
                    Vector2 velocity = player2Rb2d.velocity;
                    velocity.y = jumpForce;
                    player2Rb2d.velocity = velocity;
                }
            }
            Score.scoreValue += 10;

            hitAmount_Current++;

            if (hitAmount_Current >= hitAmount_Max)
            {
                Destroy(gameObject);
            }
        }
    }
