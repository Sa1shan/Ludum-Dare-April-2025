using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.UI_Logic
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] private int mainGameplaySceneNumber = 1;
        public void AppQuit()
        {
            Application.Quit();
        }

        public void NextScene()
        {
            SceneManager.LoadScene(mainGameplaySceneNumber);
        }

        public void LoadSceneAfterDeath()
        {
            SceneManager.LoadScene(mainGameplaySceneNumber);
            SceneLaunchTracker.HadSceneBeenLoadBefore = true;
        }
    }
}
