using UnityEngine;

namespace _Source.UI_Logic
{
   public class TimeScale : MonoBehaviour
   {
      [SerializeField] private Pause pause;
      public void OnButton()
      {
         Time.timeScale = 1;
         pause.Vignette.SetActive(pause.IsActive);
      }
   }
}
