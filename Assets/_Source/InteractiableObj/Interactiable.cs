using UnityEngine;

namespace _Source.InteractiableObj
{
    public class Interactiable : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject messages;
        
        private void Start()
        {
            messages.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Player entered");
                messages.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (messages.activeSelf)
                {
                    messages.SetActive(false);
                }
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                messages.SetActive(false);
                CheckActive.Instance.IsActiveHm = true;
            }
        }
    }
}
