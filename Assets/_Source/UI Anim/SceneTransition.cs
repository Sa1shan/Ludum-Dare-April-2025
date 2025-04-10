using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace _Source.UI_Anim
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private Image fadeImage; // Альфа по умолчанию = 0
        [SerializeField] private float fadeDuration = 1f;

        private void Start()
        {
            // Включаем Image, чтобы он был виден
            fadeImage.gameObject.SetActive(true);

            // Получаем текущий цвет и устанавливаем альфу = 1
            Color newColor = fadeImage.color;
            newColor.a = 1f;
            fadeImage.color = newColor;

            // Плавное исчезновение
            fadeImage.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
        }
    }
}
