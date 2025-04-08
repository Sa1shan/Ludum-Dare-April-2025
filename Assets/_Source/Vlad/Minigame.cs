using System.Collections;
using TMPro;
using UnityEngine;

namespace _Source.Vlad
{
    public class Minigame : MonoBehaviour
    {
        [SerializeField] private GameObject minigamePanel;
        [SerializeField] private RectTransform barArea;
        [SerializeField] private RectTransform arrow;
        [SerializeField] private RectTransform successZone;
        [SerializeField] private TMP_Text cooldownText;

        [SerializeField] private float arrowSpeed = 200f;
        [SerializeField] private float cooldownTime = 20f;

        private TempSlider _tempPanel;
        private bool _isActive = false;
        private bool _isOnCooldown = false;
        private bool _movingRight = true;
        private float _currentCooldown;

        private void Start()
        {
            _tempPanel = FindObjectOfType<TempSlider>();
            cooldownText.text = "Нажмите <P>, чтобы согреться!";
            cooldownText.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) && !_isActive && !_isOnCooldown)
            {
                StartMiniGame();
            }

            if (_isActive)
            {
                MoveArrow();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CheckSuccess();
                }
            }
        
            if (_isOnCooldown)
            {
                _currentCooldown -= Time.deltaTime;
                cooldownText.text = $"Можно согреться через: {Mathf.Ceil(_currentCooldown)} сек";
            
                if (_currentCooldown <= 0)
                {
                    _isOnCooldown = false;
                    cooldownText.text = "Нажмите <P>, чтобы согреться!";
                }
            }
        }

        private void StartMiniGame()
        {
            cooldownText.gameObject.SetActive(false);
            _isActive = true;
            minigamePanel.SetActive(true);
            arrow.anchoredPosition = new Vector2(-barArea.rect.width / 2f, arrow.anchoredPosition.y);
            _movingRight = true;
        }

        private void EndMiniGame()
        {
            _isActive = false;
            minigamePanel.SetActive(false);
            _isOnCooldown = true;
            _currentCooldown = cooldownTime;
            cooldownText.gameObject.SetActive(true);
        }

        private IEnumerator CooldownRoutine()
        {
            yield return new WaitForSeconds(cooldownTime);
            _isOnCooldown = false;
            cooldownText.gameObject.SetActive(false);
        }

        private void MoveArrow()
        {
            var step = arrowSpeed * Time.deltaTime * (_movingRight ? 1 : -1);
            arrow.anchoredPosition += new Vector2(step, 0);

            var halfWidth = barArea.rect.width / 2f;

            if (arrow.anchoredPosition.x > halfWidth)
            {
                arrow.anchoredPosition = new Vector2(halfWidth, arrow.anchoredPosition.y);
                _movingRight = false;
            }
            else if (arrow.anchoredPosition.x < -halfWidth)
            {
                arrow.anchoredPosition = new Vector2(-halfWidth, arrow.anchoredPosition.y);
                _movingRight = true;
            }
        }

        private void CheckSuccess()
        {
            var arrowX = arrow.anchoredPosition.x;
            var zoneLeft = successZone.anchoredPosition.x - (successZone.rect.width / 16f);
            var zoneRight = successZone.anchoredPosition.x + (successZone.rect.width / 16f);

            if (arrowX >= zoneLeft && arrowX <= zoneRight)
            {
                Debug.Log("Успех!");
                _tempPanel.AddTemp();
            }
            else
            {
                Debug.Log("Провал!");
            }

            EndMiniGame();
        }
    }
}