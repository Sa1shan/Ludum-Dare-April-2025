using _Source.Vlad;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace _Source.UI_Anim
{
    public class UIFade : MonoBehaviour
    {
        [SerializeField] private GameObject firstPanel;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private CanvasGroup canvasGroup2;
        [SerializeField] private GameObject tempSliderController;

        private bool _hasFade = false; // чтобы анимация сработала только один раз
        private bool _fadeIn = false;
        
        private void Start()
        {
            canvasGroup.gameObject.SetActive(false);
            canvasGroup.alpha = 0f;
            tempSliderController.GetComponent<TempSlider>().enabled = false;
        }

        private void Update()
        {
            if (!firstPanel.activeSelf && !_hasFade)
            {
                canvasGroup.gameObject.SetActive(true);
                _hasFade = true;

                // Подождать 1 секунду, потом выцветание за 3 секунды
                DOVirtual.DelayedCall(1f, () =>
                {
                    canvasGroup.DOFade(1f, 3f); // анимация
                    _fadeIn = true;
                });
            }

            if (_fadeIn)
            {
                tempSliderController.GetComponent<TempSlider>().enabled = true;
                DOVirtual.DelayedCall(10f, () => // Подождать 2 секунды
                {
                    canvasGroup2.DOFade(0f, 3f); // Исчезновение
                });
            }
        }
    }
}
