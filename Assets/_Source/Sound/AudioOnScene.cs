using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnScene : MonoBehaviour
{
    public AudioClip musicClip; 
    private AudioSource audioSource;
    [SerializeField] private Slider slider;

    void Start()
    {
        // Создаем и настраиваем AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.volume = slider.value;
        audioSource.loop = true; // Зацикливаем музыку
        audioSource.playOnAwake = true; // Автозапуск при старте
        
        // Запускаем музыку
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = slider.value;
    }
}

