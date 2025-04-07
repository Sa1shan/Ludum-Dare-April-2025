using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    private Vector3 lastPosition;

    public float movementThreshold = 0.01f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
        audioSource.loop = true;
    }

    private void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        if (distanceMoved > movementThreshold)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }

        lastPosition = transform.position;
    }
}