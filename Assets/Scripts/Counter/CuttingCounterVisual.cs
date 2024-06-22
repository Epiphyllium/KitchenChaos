using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CuttingCounterVisual : MonoBehaviour
    {
        private Animator cutAnim;
        private const string CUT = "Cut";
        private void Start()
        {
            cutAnim = GetComponent<Animator>();
        }
        public void playCut()
        {
            cutAnim.SetTrigger(CUT);
        }
    }

}