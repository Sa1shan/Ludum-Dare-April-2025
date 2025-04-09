using UnityEngine;
using UnityEngine.SceneManagement;


namespace _Source.UI_Logic
{
    public class TutorialOff : MonoBehaviour
    {
        [SerializeField] private GameObject uIAnimController;

        void Awake()
        {
            if (SceneLaunchTracker.HadSceneBeenLoadBefore)
            {
                Destroy(uIAnimController);
            }
        }
    }
}
