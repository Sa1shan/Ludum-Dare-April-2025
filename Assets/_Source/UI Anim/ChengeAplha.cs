using System.Collections.Generic;
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
        [SerializeField] private List<GameObject> interactiableObj;

        private void Start()
        {
            Color color = messege.color;
            color.a = 0f;
            messege.color = color;
            Color c = messegeText.color;
            c.a = 0f;
            messegeText.color = c;
            DisableSecondUsing(true);
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

            if (CheckActive.Instance.isExit)
            {
                DisableSecondUsing(false);
            }
        }

        private void SetActive()
        {
            messege.DOFade(0f, 2f);
            messegeText.DOFade(0f, 2f);
        }

        private void DisableSecondUsing(bool disable)
        {
            foreach (GameObject obj in interactiableObj)
            {
                obj.SetActive(disable);
            }
        }
    }
}
