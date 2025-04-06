using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float time = 60f;
    private float _decreaseRate;
    [SerializeField] private float addTemperature;
    [SerializeField] private ShowAddedTemp tempDisplay;

    public void AddTemp()
    {
        slider.value += addTemperature;
        if (tempDisplay != null)
        {
            tempDisplay.ShowTemp(addTemperature);
        }
    }

    public void ShowAddedTemp(TMP_Text addedTempTMPText)
    {
        addedTempTMPText.gameObject.SetActive(true);
    }

    private void Start()
    {
        if (slider != null)
        {
            slider.value = slider.maxValue;
            _decreaseRate = slider.maxValue / time;
        }
    }

    private void Update()
    {
        if (slider != null && slider.value > 0)
        {
            slider.value -= _decreaseRate * Time.deltaTime;

            if (slider.value <= 0)
            {
                slider.value = 0;
                Death();
            }
        }
    }

    private static void Death()
    {
        Debug.Log("Игрок замёрз!");
    }
}
