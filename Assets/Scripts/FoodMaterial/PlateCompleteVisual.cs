using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public class FoodMaterialSO_Model
    {
        public FoodMaterialSO foodSO;
        public GameObject model;
    }

    [SerializeField] private List<FoodMaterialSO_Model> modelMap;
    
    public void ShowFoodMaterial(FoodMaterialSO foodSO)
    {
        foreach (var item in modelMap)
        {
            if (item.foodSO == foodSO)
            {
                item.model.SetActive(true);
                return;
            }
        }
    }
    
}
