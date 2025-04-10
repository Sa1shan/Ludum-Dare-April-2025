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

    private Sequence _sequence;

    private void Start()
    {
        // Устанавливаем начальную позицию панели за пределами экрана (слева, например)
        image.rectTransform.anchoredPosition = new Vector2(startPosX, image.rectTransform.anchoredPosition.y);

        // Создаём первую последовательность анимаций — первичный показ
        _sequence = DOTween.Sequence();

        // 1. Панель появляется (движется слева направо)
        _sequence.Append(image.rectTransform.DOAnchorPosX(endPosX, 2f).SetEase(Ease.OutQuad)); 

        // 2. Задержка на экране 2 секунды
        _sequence.AppendInterval(2f); 

        // 3. Панель уходит обратно (движется справа налево)
        _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad)); 

        // 4. После завершения первой анимации запускаем вторую (с другим текстом)
        _sequence.AppendCallback(() =>
        {
            PlaySequence(); 
        });
    }

    private void PlaySequence()
    {
        // Если предыдущая последовательность всё ещё активна — убиваем её
        if (_sequence != null && _sequence.IsActive())
        {
            _sequence.Kill();
        }

        // Создаём вторую последовательность анимаций — с новым текстом
        _sequence = DOTween.Sequence();

        // 1. Небольшая пауза перед показом новой надписи
        _sequence.AppendInterval(0.1f);

        // 2. Меняем текст на тот, что задан в инспекторе (например, "WASD для передвижения")
        _sequence.AppendCallback(() => ChangeText(textToDisplay));

        // 3. Панель снова появляется
        _sequence.Append(image.rectTransform.DOAnchorPosX(endPosX, 2f).SetEase(Ease.InOutQuad));

        // 4. Панель держится на экране 6 секунд
        _sequence.AppendInterval(6f);

        // 5. Панель уходит
        _sequence.Append(image.rectTransform.DOAnchorPosX(startPosX, 2f).SetEase(Ease.InOutQuad));

        // 6. После ухода панели — полностью отключаем объект
        _sequence.OnComplete(() =>
        {
            image.gameObject.SetActive(false);
        });
    }

    // Метод для смены текста на панели
    public void ChangeText(string newText)
    {
        text.text = newText;
    }
}
}
