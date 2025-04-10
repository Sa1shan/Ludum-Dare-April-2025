using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace _Source.UI_Anim
{
    public class SceneTransition : MonoBehaviour
    { 
        public Image fadeImage; // Альфа задаётся вручную в инспекторе
        public float fadeDuration = 1f;

        private void Start()
        {
            if (fadeImage.color.a > 0f)
            {
                // Включаем Image на всякий случай
                fadeImage.gameObject.SetActive(true);

                // Плавное появление
                fadeImage.DOFade(0f, fadeDuration).OnComplete(() =>
                {
                    fadeImage.gameObject.SetActive(false);
                });
            }
            else
            {
                fadeImage.gameObject.SetActive(false);
            }
        }
    }
}
