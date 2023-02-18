using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffect : MonoBehaviour
{
    public AudioClip ButtonPress; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnButtonPress()
    {
        audioSource.PlayOneShot(ButtonPress, 0.5f);
    }
}
