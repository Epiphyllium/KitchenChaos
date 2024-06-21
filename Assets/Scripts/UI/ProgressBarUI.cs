using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressImage;
    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateProgress(float progress)
    {
        Show();
        progressImage.fillAmount = progress;

        if (Math.Abs(progress - 1) < 0.000001)
        {
            Invoke("Hide",0.5f);
        }
    }
}
