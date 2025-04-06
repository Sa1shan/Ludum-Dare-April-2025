using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{

    [SerializeField] private GameObject minigamePanel;
    [SerializeField] private RectTransform barArea;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform successZone;

    [SerializeField] private float arrowSpeed = 200f;
    [SerializeField] private float cooldownTime = 20f;

    private TempSlider tempPanel;

    private bool isActive = false;
    private bool isOnCooldown = false;
    private bool movingRight = true;
    private void Start()
    {
        tempPanel = FindObjectOfType<TempSlider>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isActive && !isOnCooldown)
        {
            StartMinigame();
        }

        if (isActive)
        {
            MoveArrow();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckSuccess();
            }
        }
    }

    public void StartMinigame()
    {
        isActive = true;
        isOnCooldown = true;
        minigamePanel.SetActive(true);

        arrow.anchoredPosition = new Vector2(-barArea.rect.width / 2f, arrow.anchoredPosition.y);
        movingRight = true;
    }

    private void EndMinigame()
    {
        isActive = false;
        minigamePanel.SetActive(false);
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    private void MoveArrow()
    {
        float step = arrowSpeed * Time.deltaTime * (movingRight ? 1 : -1);
        arrow.anchoredPosition += new Vector2(step, 0);

        float halfWidth = barArea.rect.width / 2f;

        if (arrow.anchoredPosition.x > halfWidth)
        {
            arrow.anchoredPosition = new Vector2(halfWidth, arrow.anchoredPosition.y);
            movingRight = false;
        }
        else if (arrow.anchoredPosition.x < -halfWidth)
        {
            arrow.anchoredPosition = new Vector2(-halfWidth, arrow.anchoredPosition.y);
            movingRight = true;
        }
    }

    private void CheckSuccess()
    {
        float arrowX = arrow.anchoredPosition.x;
        float zoneLeft = successZone.anchoredPosition.x - (successZone.rect.width / 16f);
        float zoneRight = successZone.anchoredPosition.x + (successZone.rect.width / 16f);

        if (arrowX >= zoneLeft && arrowX <= zoneRight)
        {
            Debug.Log("ÓÑÏÅÕ!");
            tempPanel.Addtemp();
        }
        else
        {
            Debug.Log("ÏÐÎÌÀÕ!");

        }

        EndMinigame();
    }
}
