using UnityEngine;
using UnityEngine.SceneManagement;


namespace _Source.UI_Logic
{
    public class TutorialOff : MonoBehaviour
    {
        [SerializeField] private GameObject uIController;

        void Start()
        {
            if (SceneLaunchTracker.HadSceneBeenLoadBefore)
            {
                Destroy(uIController);
            }
        }
        public void OffTutorialScripts()
        {
            SceneManager.LoadScene("GlobalScene 1");
            SceneLaunchTracker.HadSceneBeenLoadBefore = true;
        }
    }
}
