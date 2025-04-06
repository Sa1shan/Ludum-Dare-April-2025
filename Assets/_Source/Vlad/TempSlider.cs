using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float time = 60f;
    private float decreaseRate;
    [SerializeField] private float addTemperature;

    public void Addtemp()
    {
        slider.value += addTemperature;
    }

    void Start()
    {
        if (slider != null)
        {
            slider.value = slider.maxValue;
            decreaseRate = slider.maxValue / time;
        }
    }

    void Update()
    {
        if (slider != null && slider.value > 0)
        {
            slider.value -= decreaseRate * Time.deltaTime;

            if (slider.value <= 0)
            {
                slider.value = 0;
                Death();
            }
        }
    }

    void Death()
    {
        Debug.Log("Игрок замёрз!");
    }
}
