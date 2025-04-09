using _Source.Vlad;
using UnityEngine;

namespace _Source.UI_Logic
{
    public class Pause : MonoBehaviour
    {   
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject miniGameController;
        [SerializeField] private GameObject vignette;
        
        
        private void Start()
        {
            pauseMenu.SetActive(false);
            miniGameController.GetComponent<Minigame>().enabled = true;
        }

        void Update()
        {
            OnButtonClick();
        }

        public void OnButtonClick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                bool isPaused = !pauseMenu.activeSelf;
                pauseMenu.SetActive(isPaused);
                bool isActive = vignette.activeSelf;
                vignette.gameObject.SetActive(!isActive);
                Time.timeScale = isPaused ? 0 : 1;

                if (isPaused)
                {
                    miniGameController.GetComponent<Minigame>().enabled = true;
                }
                
                
            }
            
            
        }
    }
}
