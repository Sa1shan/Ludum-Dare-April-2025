using _Source.UI_Anim;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace _Source.InteractiableObj
{
    public class Interactiable : MonoBehaviour
    {
        [SerializeField] private Image eMessages;
        [SerializeField] private Text eText;
        [SerializeField] private string interactText; // уникальный текст для каждого объекта
        [SerializeField] private ChengeAplha chengeAlpha;

        private bool playerInZone = false;

        private void Start()
        {
            eMessages.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerInZone = true;
                eText.text = "Нажмите E";
                eMessages.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerInZone = false;
                eMessages.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (playerInZone && Input.GetKeyDown(KeyCode.E))
            {
                eMessages.gameObject.SetActive(false);
                chengeAlpha.ShowText(interactText);
                gameObject.SetActive(false); // отключаем интерактив
            }
        }
    }
}
