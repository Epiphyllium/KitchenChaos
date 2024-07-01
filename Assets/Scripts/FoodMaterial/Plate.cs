using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace DefaultNamespace
{
    public class Plate:FoodMaterial
    {
        [SerializeField]private List<FoodMaterialSO> _validFoodSOList;
        [SerializeField]private PlateCompleteVisual _visual;
        private List<FoodMaterialSO> _foodSOList = new List<FoodMaterialSO>();
        
        public bool TryAddFoodMaterial(FoodMaterialSO foodSO)
        {
            if (_foodSOList.Contains(foodSO) || !_validFoodSOList.Contains(foodSO))
            {
                return false;
            }
            _foodSOList.Add(foodSO);
            _visual.ShowFoodMaterial(foodSO);
            return true;
        }
    }
}