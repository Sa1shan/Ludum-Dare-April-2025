using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Logic
{
    public class DeathLogic : MonoBehaviour
    {
        [SerializeField] private Slider deathSlider;
        [SerializeField] private Image deathImage;

        private void Update()
        {
            if (deathSlider.value == 0)
            {
                deathImage.gameObject.SetActive(true);
            }
        }
    }
}
