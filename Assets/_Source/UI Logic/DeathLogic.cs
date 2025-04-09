using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace _Source.UI_Logic
{
    public class DeathLogic : MonoBehaviour
    {
        [SerializeField] private Slider deathSlider;
        [SerializeField] private Image deathImage;
        [SerializeField] private Image temperatureSprite;


        private void Start()
        {
            
            if (temperatureSprite != null)
            {
                temperatureSprite.DOFade(0, 0.001f);
            }
        }
        
        private void Update()
        {
            if (deathSlider.value == 0)
            {
                temperatureSprite.gameObject.SetActive(false);
                deathImage.gameObject.SetActive(true);
            }

            if (deathSlider.value <= 30 & deathSlider.value > 0)
            {
                temperatureSprite.gameObject.SetActive(true);
                SetTimeAnimation();
            }
            else
            {
                temperatureSprite.DOKill();
                Color spriteColor = temperatureSprite.color;
                spriteColor.a = 0f;
                temperatureSprite.color = spriteColor;
            }
        }

        private void SetTimeAnimation()
        {
            temperatureSprite.DOFade(1, 40);
            
        }
    }
}
