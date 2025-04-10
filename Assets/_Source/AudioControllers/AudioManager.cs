using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip object1Music;
    [SerializeField] private AudioClip object2Music;
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Подписываемся на событие
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Отписываемся при уничтожении
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Останавливаем музыку при загрузке новой сцены
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
}