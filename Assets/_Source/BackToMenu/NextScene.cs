using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.BackToMenu
{
    public class NextScene : MonoBehaviour
    {
        [SerializeField] private int nextSceneIndex;
        [SerializeField] private GameObject pressE;

        private bool playerInTrigger = false;

        void Start()
        {
            pressE.SetActive(false); // Объект не виден в начале
        }

        void Update()
        {
            // Проверка на нажатие клавиши E, если игрок в триггер-зоне
            if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
            {
                LoadNextScene(); // Переход на следующую сцену
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                pressE.SetActive(true); // Показываем объект
                playerInTrigger = true; // Игрок вошел в триггер-зону
                Debug.Log("Player entered");
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                pressE.SetActive(false); // Скрываем объект
                playerInTrigger = false; // Игрок покинул триггер-зону
            }
        }

        void LoadNextScene()
        {
            SceneManager.LoadScene(nextSceneIndex); // Загружаем следующую сцену
        }
    }
}
