using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    
    public class FoodMaterialHolder: MonoBehaviour
    {
        private FoodMaterialHolder _targetHolder;
        private FoodMaterial _holdingFood;
        [FormerlySerializedAs("_HoldPoint")] [FormerlySerializedAs("_foodTrans")] [SerializeField] private Transform _holdPoint;
        
        public FoodMaterial GetHoldingFood()
        {
            return _holdingFood;
        }

        public void SetHoldingFood(FoodMaterial food)
        {
            food.transform.localPosition = Vector3.zero;
            _holdingFood = food;
        }
        public Transform GetHoldPoint()
        {
            return _holdPoint;
        }
        
        public FoodMaterialHolder GetTargetHolder()
        {
            return _targetHolder;
        }
        public void PutFoodOnHolder(FoodMaterial foodMaterial)
        {
            foodMaterial.transform.SetParent(_holdPoint);
            foodMaterial.transform.localPosition = Vector3.zero;
            this._holdingFood = foodMaterial;
        }

        public bool IsHoldingFood()
        {
            return _holdingFood != null;
        }
        public void ClearFoodOnHolder()
        {
            this._holdingFood = null;
        }

        public void DestroyFoodMaterialOnHolder()
        {
            if (_holdingFood == null)
            {
                Debug.LogError("There is no object can be destroyed");
            }
            Destroy(_holdingFood.gameObject);
            ClearFoodOnHolder();
        }

        public void FoodMaterialTransfer(FoodMaterialHolder sourceHolder, FoodMaterialHolder targetHolder)
        {
            var transFood = sourceHolder.GetHoldingFood();
            if (transFood == null)
            {
                Debug.LogWarning("There is no food on sourceCounter:"+this.gameObject);
                return;
            }
            if (targetHolder.GetHoldingFood() != null)
            {
                Debug.LogWarning("There is "+ targetHolder.GetHoldingFood().gameObject+ "on" + targetHolder.gameObject);
                return;
            }
            targetHolder.PutFoodOnHolder(transFood);
            sourceHolder.ClearFoodOnHolder();
        }
    }
}