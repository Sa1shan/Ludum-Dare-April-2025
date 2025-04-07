using System;
using UnityEngine;

namespace _Source.UI_ANim
{
    public class AnimGameplayUI : MonoBehaviour
    {
        [SerializeField] private GameObject firstPanel;

        private void Update()
        {
            if (!firstPanel.activeSelf)
            {
                Debug.Log("Gameplay disabled");
            }
        }
    }
}
