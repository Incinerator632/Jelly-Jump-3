using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundOnButtonTouch : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip soundEffect; // Assign the sound effect in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(soundEffect);
    }
}
