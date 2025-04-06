using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization; // Для перехода между сценами

public class UISwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Text gameObjectText;
    [SerializeField] private List<string> texts = new List<string>(); // Список текстов
    [SerializeField] private float textSpeed = 0.05f; // Скорость анимации
    private const string MainGameplaySceneName = "GlobalScene"; // Имя сцены для перехода
    [SerializeField] private GameObject page1;

    private int _currentTextIndex = 0;
    private bool _isAnimating = false;
    private bool _isLastTextReached = false;

    private void Start()
    {
        if (texts.Count <= 0) return;
        gameObjectText.text = "";
        StartCoroutine(TextAnimation(texts[_currentTextIndex]));
    }

    private void Update()
    {
        // Если нажата левая кнопка мыши
        if (!Input.GetMouseButtonDown(0) || page1 == null || !page1.activeInHierarchy) 
            return;
        // Если анимация идёт – пропустить её
            if (_isAnimating)
            {
                StopAllCoroutines();
                gameObjectText.text = texts[_currentTextIndex];
                _isAnimating = false;

                // Если это последний текст – разрешить переход
                if (_currentTextIndex == texts.Count - 1)
                    _isLastTextReached = true;
            }
            // Если анимация завершена – переключить текст или сцену
            else
            {
                if (_isLastTextReached)
                {
                    MainGameplaySceneLoad();
                }
                else
                {
                    ShowNextText();
                }
            }
    }


    private void ShowNextText()
    {
        if (texts.Count == 0) return;

        _currentTextIndex++;
        gameObjectText.text = "";

        // Если это последний текст – включить флаг
        if (_currentTextIndex == texts.Count - 1)
            _isLastTextReached = true;

        StartCoroutine(TextAnimation(texts[_currentTextIndex]));
    }

    private IEnumerator TextAnimation(string fullText)
    {
        _isAnimating = true;

        foreach (var letter in fullText)
        {
            gameObjectText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        _isAnimating = false;
    }

    private static void MainGameplaySceneLoad()
    {
        if (!string.IsNullOrEmpty(MainGameplaySceneName))
        {
            SceneManager.LoadScene(MainGameplaySceneName);
        }
        
    }
}