using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [Header("Музыка для сцен")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gamePlayScene;
    [SerializeField] private AudioClip finalScene;
    
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "StartScene":
                PlayMusic(mainMenuMusic);
                break;
            case "GlobalScene":
                PlayMusic(gamePlayScene);
                break;
            case "FinalScene":
                PlayMusic(finalScene);
                break;
            default:
                StopMusic();
                break;
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        
        if (musicSource.clip != clip || !musicSource.isPlaying)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}