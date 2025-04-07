using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Switch_UI_On_Start_Scene
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
    }
}
