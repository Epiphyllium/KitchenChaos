using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounterVisual : MonoBehaviour
{
    private Animator _openCloseAnimator;
    private const string OPEN_CLOSE = "OpenClose";
    // Start is called before the first frame update
    void Start()
    {
        _openCloseAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOpen()
    {
        _openCloseAnimator.SetTrigger(OPEN_CLOSE);
    }
}
