using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI_Anim
{
    public class AnimDoTween : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float startPosX;
        [SerializeField] private float endPosX;
        [SerializeField] private Text text;
        [TextArea] [SerializeField] private string textToDisplay;
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
            if (_sequence != null && _sequence.IsActive())
            {
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();

            _sequence.AppendInterval(1f);
            
            _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad));
            
            _sequence.AppendCallback(() => ChangeText(textToDisplay));
            
            _sequence.AppendInterval(0.5f);
            
            _sequence.Append(image.rectTransform.DOAnchorPosX(endPosX, 2f).SetEase(Ease.InOutQuad));
            
            _sequence.AppendInterval(6f);
            
            _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad));
            _sequence.OnComplete(() =>
            {
                image.gameObject.SetActive(false);
            });
        }

        public void ChangeText(string newText)
        {
            text.text = newText;
        }
    }
}
