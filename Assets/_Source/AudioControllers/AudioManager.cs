using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Source.AudioControllers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioClip object1Music;
        [SerializeField] private AudioClip object2Music;
        [SerializeField] private AudioSource musicSource;

        [Header("Background Music")]
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioSource backgroundSource;

        [Header("UI Volume Control")]
        [SerializeField] private Slider backgroundVolumeSlider;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += OnSceneLoaded;

                // Запускаем фоновую музыку, если есть
                if (backgroundMusic != null && backgroundSource != null)
                {
                    backgroundSource.clip = backgroundMusic;
                    backgroundSource.loop = true;
                    backgroundSource.Play();
                }

                // Подключаем слушатель к слайдеру, если он задан
                if (backgroundVolumeSlider != null)
                {
                    backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);
                    backgroundSource.volume = backgroundVolumeSlider.value;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (backgroundVolumeSlider != null)
            {
                backgroundVolumeSlider.onValueChanged.RemoveListener(SetBackgroundVolume);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StopMusic();
        }

        public void PlayObject1Music()
        {
            if (musicSource.clip != object1Music || !musicSource.isPlaying)
            {
                musicSource.clip = object1Music;
                musicSource.Play();
            }
        }

        public void PlayObject2Music()
        {
            if (musicSource.clip != object2Music || !musicSource.isPlaying)
            {
                musicSource.clip = object2Music;
                musicSource.Play();
            }
        }

        private void StopMusic()
        {
            musicSource.Stop();
        }

        public void SetBackgroundVolume(float value)
        {
            if (backgroundSource != null)
            {
                backgroundSource.volume = value;
            }
        }
    }
}