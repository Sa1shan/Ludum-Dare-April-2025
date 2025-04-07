using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasPlayed)
            return;

        if (other.CompareTag("Player") || other.gameObject != null)
        {
            audioSource.enabled = true;
            audioSource.Play();
            hasPlayed = true;
        }
    }
}