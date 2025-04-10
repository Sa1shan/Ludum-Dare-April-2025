using System.Collections.Generic;
using _Source.InteractiableObj;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Anim
{
    public class ChengeAplha : MonoBehaviour
    {
        [SerializeField] private Image messageImage;
        [SerializeField] private Text messageText;

        private void Start()
        {
            // Устанавливаем альфа 0 при старте
            SetAlpha(0f);
        }

        private void SetAlpha(float alpha)
        {
            Color imgColor = messageImage.color;
            imgColor.a = alpha;
            messageImage.color = imgColor;

            Color textColor = messageText.color;
            textColor.a = alpha;
            messageText.color = textColor;
        }

        public void ShowText(string text)
        {
            messageText.text = text;

            messageImage.DOFade(1f, 2f);
            messageText.DOFade(1f, 2f);

            Invoke(nameof(HideText), 3f);
        }

        private void HideText()
        {
            messageImage.DOFade(0f, 2f);
            messageText.DOFade(0f, 2f);
        }
    }
}
