using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip JumpSound;
    private Rigidbody2D player2Rb2d;
    private GameManager gameManager;
    private AudioSource playerAudio;
    private float speed = 10f;
    private float horizontalInput;
    private float xRange = 14;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player2Rb2d.velocity = new Vector2(horizontalInput * speed, player2Rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        playerAudio.PlayOneShot(JumpSound, 0.5f);
    }
}
