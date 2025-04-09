using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace _Source.InteractiableObj
{
    public class Interactiable : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Image eMessages;
        [SerializeField] private Text eText;
        [SerializeField] private Image messagesSmth;
        
        private bool onTriggerEnter = false;
        private void Start()
        {
            Color color = messagesSmth.color;
            color.a = 0f;
            messagesSmth.color = color;
            eMessages.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                onTriggerEnter = true;
                Debug.Log("Player entered");
                eMessages.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                eMessages.gameObject.SetActive(false);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && onTriggerEnter)
            {
                eMessages.gameObject.SetActive(false);
                CheckActive.Instance.IsActiveHm = true;
                CheckActive.Instance.isExit = true;
            }

            if (messagesSmth.color.a != 0f)
            {
                eMessages.gameObject.SetActive(false);
            }
        }
    }
}
