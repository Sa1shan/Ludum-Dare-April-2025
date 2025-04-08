using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Anim
{
    public class AnimDoTween : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float startPosX;
        [SerializeField] private float endPosX;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private string textToDisplay;
        private Sequence _sequence; // Храним _sequence, чтобы можно было отменить при необходимости
        private Tween _currentTween;
        private bool _isFirstMessageShown = false;
        private void Start()
        {
            // Первичный показ через 2 секунды
            image.rectTransform.anchoredPosition = new Vector2(startPosX, image.rectTransform.anchoredPosition.y);
            image.rectTransform.DOAnchorPosX(endPosX, 2f).SetEase(Ease.OutQuad);
            _isFirstMessageShown = true;
        }

        private void Update()
        {
            if (_isFirstMessageShown && Input.GetKeyDown(KeyCode.T))
            {
                PlaySequence();
                _isFirstMessageShown = false; // блокируем повторное нажатие
            }
        }

        private void PlaySequence()
        {
            // Убиваем предыдущую последовательность, если она ещё идёт
            if (_sequence != null && _sequence.IsActive())
            {
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();

            _sequence.AppendInterval(1f); // ждём перед началом

            // 1. Прячем панель (анимация движения влево)
            _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad));

            // 2. Меняем текст
            _sequence.AppendCallback(() => ChangeText(textToDisplay));

            // 3. Небольшая пауза перед показом
            _sequence.AppendInterval(0.5f);

            // 4. Показываем панель (анимация движения вправо)
            _sequence.Append(image.rectTransform.DOAnchorPosX(endPosX, 2f).SetEase(Ease.InOutQuad));

            // 5. Держим панель на экране немного
            _sequence.AppendInterval(6f);

            // 6. Снова прячем
            _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad));
            // 7. После завершения всей последовательности — деактивируем панель
            _sequence.OnComplete(() =>
            {
                image.gameObject.SetActive(false); // Отключаем объект, на котором висит этот скрипт
            });
        }

        public void ChangeText(string newText)
        {
            text.text = newText;
        }
    }
}
