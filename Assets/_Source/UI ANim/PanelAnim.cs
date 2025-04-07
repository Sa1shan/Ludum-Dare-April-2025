using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

namespace _Source.UI_ANim
{
    public class PanelAnim : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public string textToDisplay;
        public RectTransform uiElement; // Ваш UI элемент
        public Vector2 targetPositionStart; // Вторая целевая позиция
        public Vector2 targetPositionBack; // Первая целевая позиция
        public float moveSpeed = 5f;    // Скорость движения
        public GameObject panel;
        public GameObject temperturePanel;
        public GameObject temperturePanelText;
        private Vector2 currentTarget;

        private bool _isStart;
        private bool _isHide;
        private bool _isEnd;
        void Start()
        {
            currentTarget = targetPositionStart;
            Invoke("ShowPanel", 2f);
            _isStart = true;
        }

        void Update()
        {
            bool isShowText = false;
            if (Input.GetKeyDown(KeyCode.T) && _isStart)
            {
                Invoke("HidePanel", 0.5f);
                Invoke("ChangeTextInv", 1f);
                _isHide = true;
            }

            if (_isHide)
            {
                Invoke("ShowPanel", 4f);
                Invoke("HidePanel", 6f);
                _isEnd = true;
            }
            uiElement.anchoredPosition = Vector2.Lerp(uiElement.anchoredPosition, currentTarget, moveSpeed * Time.deltaTime);

            if (_isEnd)
            {
                Invoke("ShowText", 10f);
                Invoke("ShowTemPanel", 10f);
                isShowText = true;
            }
            bool isEndAll = false;
            if (isShowText)
            {
                Invoke("HideText", 15f);
                Invoke("HideTempText", 26f);
                isEndAll = true;
            }
        }
        
        void ShowTemPanel()
        {
            temperturePanel.SetActive(true);
        }

        void HideTempText()
        {
            temperturePanelText.SetActive(false);
        }
        void ShowPanel()
        {
            currentTarget = targetPositionStart;
        }

        void HidePanel()
        {
            currentTarget = targetPositionBack;
        }

        void ShowText()
        {
            panel.SetActive(true);
        }

        void HideText()
        {
            panel.SetActive(false);
        }
        public void ChangeText(string newText)
        {
            text.text = newText;
        }
        
        void ChangeTextInv()
        {
            ChangeText(textToDisplay);
        }
        
        // public TextMeshProUGUI text;
        // public string textToDisplay;
        //
        // private bool _isTextChange = false;
        //
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.T))
        //     {
        //         Invoke("ChangeTextInv", 1f);
        //         _isTextChange = true;
        //     }
        //
        //     if (_isTextChange)
        //     {
        //         Invoke("HidePanelFirst", 6f);
        //     }
        // }
        //
        //
        //
    }
}
