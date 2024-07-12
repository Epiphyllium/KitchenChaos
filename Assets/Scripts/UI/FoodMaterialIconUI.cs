using UnityEngine;
using UnityEngine.UI;
using System;
public class FoodMaterialIconUI: MonoBehaviour
{
    [SerializeField] private Image _iconImage;

    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        _iconImage.sprite = sprite;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
