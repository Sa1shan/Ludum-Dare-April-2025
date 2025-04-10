using _Source.Vlad;
using UnityEngine;
using DG.Tweening;

namespace _Source.UI_Anim
{
    public class UIFade : MonoBehaviour
    {
        [SerializeField] private GameObject firstPanel;
        [SerializeField] private CanvasGroup temperature;
        [SerializeField] private CanvasGroup uIPanels;
        [SerializeField] private GameObject tempSliderController;
        
        private bool _hasFade = false; // чтобы анимация сработала только один раз
        private bool _fadeIn = false;
        
        private void Start()
        {
            uIPanels.gameObject.SetActive(true);
            temperature.gameObject.SetActive(false);
            temperature.alpha = 0f;
            tempSliderController.GetComponent<TempSlider>().enabled = false;
        }

        private void Update()
        {
            if (!firstPanel.activeSelf && !_hasFade)
            {
                temperature.gameObject.SetActive(true);
                _hasFade = true;

                // Подождать 1 секунду, потом выцветание за 3 секунды
                DOVirtual.DelayedCall(1f, () =>
                {
                    temperature.DOFade(1f, 3f); // анимация
                    _fadeIn = true;
                });
            }

            if (_fadeIn)
            {
                tempSliderController.GetComponent<TempSlider>().enabled = true;
                DOVirtual.DelayedCall(5f, () => // Подождать 
                {
                    uIPanels.DOFade(0f, 1f); // Исчезновение
                });
            }
        }
    }
}
