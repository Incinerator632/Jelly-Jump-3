using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnObstacleHit : MonoBehaviour
{
    public AudioClip soundEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        }
    }
}
