using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
   [SerializeField] private GameObject _stoveOnVisual;
   [SerializeField] private GameObject _sizzlingParticles;
   public void ShowStoveEffect()
   {
      _stoveOnVisual.SetActive(true);
      _sizzlingParticles.SetActive(true);
   }

   public void HideStoveEffect()
   {
      _stoveOnVisual.SetActive(false);
      _sizzlingParticles.SetActive(false);
   }
}
