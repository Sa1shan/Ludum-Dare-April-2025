using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ShowAddedTemp : MonoBehaviour
{
    [SerializeField] private TMP_Text addedTempText;
    [SerializeField] private float showTime = 1f; 
    [SerializeField] private float fadeDuration = 0.3f;

    private Coroutine _displayCoroutine;

    public void ShowTemp(float tempValue)
    {
        if (_displayCoroutine != null)
        {
            StopCoroutine(_displayCoroutine);
        }
        
        _displayCoroutine = StartCoroutine(DisplayTempRoutine(tempValue));
    }

    private IEnumerator DisplayTempRoutine(float tempValue)
    {
        addedTempText.text = $"+{tempValue}°C";
        
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsed / fadeDuration);
            addedTempText.color = new Color(addedTempText.color.r, addedTempText.color.g, addedTempText.color.b, alpha);
            yield return null;
        }
        
        float waitTime = showTime - 2 * fadeDuration;
        if (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
        }
        
        elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            addedTempText.color = new Color(addedTempText.color.r, addedTempText.color.g, addedTempText.color.b, alpha);
            yield return null;
        }
    }
}
