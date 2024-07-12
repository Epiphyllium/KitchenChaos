using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodMaterialGridUI : MonoBehaviour
{
    [FormerlySerializedAs("_iconUI")] [SerializeField]private FoodMaterialIconUI _iconTemplateUI;

    private void Start()
    {
        _iconTemplateUI.Hide();
    }

    public void ShowFoodMaterialGridUI(FoodMaterialSO foodMaterialSo)
    {
        FoodMaterialIconUI newIconUI = GameObject.Instantiate(_iconTemplateUI);
        newIconUI.transform.SetParent(transform);
        newIconUI.Show(foodMaterialSo.sprite);
    }
}
