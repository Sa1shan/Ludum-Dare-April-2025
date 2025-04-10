using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Logic
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text gameObjectText;
        [TextArea][SerializeField] private List<string> texts = new List<string>();
        [SerializeField] private float textSpeed = 0.05f;
        [SerializeField] private GameObject page1;
        [SerializeField] private Button nextSceneButton;
        [SerializeField] private TMP_Text pressMouseText;
        
        private int _currentTextIndex = 0;
        private bool _isAnimating = false;
        private bool _isLastTextReached = false;
        private void Start()
        {
            if (texts.Count <= 0)
            {
                return;
            }
            gameObjectText.text = "";
            StartCoroutine(TextAnimation(texts[_currentTextIndex]));
        }

        private void Update()
        {
            // Если нажата левая кнопка мыши
            if (!Input.GetMouseButtonDown(0) || page1 == null || !page1.activeInHierarchy)
            {
                return;
            } 
            // Если анимация идёт – пропустить её
            if (_isAnimating)
            {
                StopAllCoroutines();
                gameObjectText.text = texts[_currentTextIndex];
                _isAnimating = false;

                // Если это последний текст – разрешить переход
                if (_currentTextIndex == texts.Count - 1)
                {
                    _isLastTextReached = true;
                    
                    nextSceneButton.gameObject.SetActive(true);
                    pressMouseText.gameObject.SetActive(false);
                }
            }
            // Если анимация завершена – переключить текст или сцену
            else
            {
                if (_isLastTextReached)
                {
                    // MainGameplaySceneLoad();
                    Debug.Log("Reached the last text");
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
            {
                _isLastTextReached = true;
            }

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
            
            if (_currentTextIndex == texts.Count - 1)
            {
                _isLastTextReached = true;
                    
                nextSceneButton.gameObject.SetActive(true);
                pressMouseText.gameObject.SetActive(false);
            }
        }
    }
}
