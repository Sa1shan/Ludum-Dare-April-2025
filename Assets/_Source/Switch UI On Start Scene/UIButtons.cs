using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Switch_UI_On_Start_Scene
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] private int scenenumber;
        public void AppQuit()
        {
            Application.Quit();
        }

        public void NextScene()
        {
            SceneManager.LoadScene(scenenumber);
        }
    }
}
