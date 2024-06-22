using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GrillingRecipeSO
    {
        public FoodMaterialSO inputFood;
        public FoodMaterialSO outputFood;
        public int cookingTime;
    }
    
    [CreateAssetMenu]
    public class GrillingRecipeSOList: ScriptableObject
    {
        //TODO Using Dictionary to solve
        public List<GrillingRecipeSO> grillingRecipeList;
        
        public FoodMaterialSO GetOutputFood(FoodMaterialSO inputFood)
        {
            foreach (var grillingRecipe in grillingRecipeList)
            {
                if (grillingRecipe.inputFood == inputFood)
                {
                    return grillingRecipe.outputFood;
                }
            }
            Debug.Log("There is no food material can be grilled!");
            return null;
        }

        public bool TryGetGrillingRecipeSO(FoodMaterialSO inputFood, out GrillingRecipeSO outputFood)
        {
            foreach (var grillingRecipe in grillingRecipeList)
            {
                if (grillingRecipe.inputFood == inputFood)
                {
                    outputFood= grillingRecipe;
                    return true;
                }
            }
            Debug.Log("There is no such food material!");
            outputFood = null;
            return false;
        }
        
    }
}