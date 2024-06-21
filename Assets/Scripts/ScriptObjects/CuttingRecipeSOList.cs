using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    //TODO Using Dictionary to solve
    [Serializable]
    public class CuttingRecipeSO
    {
        public FoodMaterialSO inputFood;
        public FoodMaterialSO outputFood;
        public int cuttingCount;
    }

    [CreateAssetMenu]
    public class CuttingRecipeSOList : ScriptableObject
    {
        public List<CuttingRecipeSO> cuttingRecipeList;

        public FoodMaterialSO GetOutputFood(FoodMaterialSO inputFood)
        {
            foreach (var cuttingRecipe in cuttingRecipeList)
            {
                if (cuttingRecipe.inputFood == inputFood)
                {
                    return cuttingRecipe.outputFood;
                }
            }
            Debug.Log("There is no food material can be cut!");
            return null;
        }

        public bool TryGetCuttingRecipeSO(FoodMaterialSO inputFood, out CuttingRecipeSO outputCuttingRecipe)
        {
            foreach (var cuttingRecipe in cuttingRecipeList)
            {
                if (cuttingRecipe.inputFood == inputFood)
                {
                    outputCuttingRecipe = cuttingRecipe;
                    return true;
                }
            }
            Debug.Log("There is no such food material!");
            outputCuttingRecipe = null;
            return false;
        }
    }
}