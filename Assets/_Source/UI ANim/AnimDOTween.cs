using System;
using UnityEngine;
using DG.Tweening;
namespace _Source.UI_ANim
{
    public class AnimDoTween : MonoBehaviour
    {
       public RectTransform rectTransform;
       public float endPosX;

       private void Update()
       {
           if (Input.GetKeyDown(KeyCode.Space))
           {
               rectTransform.DOAnchorPosX(endPosX, 5f);
           }
       }

       void Show()
       {
           
       }
    }
}
