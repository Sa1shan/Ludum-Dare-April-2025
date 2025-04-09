using _Source.InteractiableObj;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Anim
{
    public class ChengeAplha : MonoBehaviour
    {
        [SerializeField] private Image messege;
        [SerializeField] private Text messegeText;
        
        void Start()
        {
            Color color = messege.color;
            color.a = 0f;
            messege.color = color;
            Color c = messegeText.color;
            c.a = 0f;
            messegeText.color = c;
        }

        void Update()
        {
            bool isfade = false;
            if (CheckActive.Instance.IsActiveHm)
            {
                messege.DOFade(1f, 2f);
                messegeText.DOFade(1f, 2f);
                CheckActive.Instance.IsActiveHm = false;
                isfade = true;
            }

            if (isfade)
            {
                Invoke("SetActive", 4f);
            }
        }

        void SetActive()
        {
            messege.DOFade(0f, 2f);
            messegeText.DOFade(0f, 2f);
        }
    }
}
