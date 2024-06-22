using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class CuttingCounter : BaseCounter
{
    private int curCuttingCount = 0;
    [SerializeField] private ProgressBarUI _cuttingProgress;
    [FormerlySerializedAs("_cuttingRecipeSoList")] [SerializeField] private CuttingRecipeSOList _cuttingRecipeSOList;
    [SerializeField] private CuttingCounterVisual _cuttingCounterVisual;
    public override void Interact(Player player)
    {
        if (player.IsHoldingFood()&&!IsHoldingFood())
        {
            curCuttingCount = 0;
            FoodMaterialTransfer(player,this);
            return;
        }

        if (!player.IsHoldingFood() && this.IsHoldingFood())
        {
            FoodMaterialTransfer(this,player);
            return;
        }
    }

    public override void Operate(Player player)
    {
        if (IsHoldingFood() )
        {
            Debug.Log("Operating....");
            FoodMaterialSO inputFoodSO = GetHoldingFood().GetFoodMaterialSO();
            if (_cuttingRecipeSOList.TryGetCuttingRecipeSO(inputFoodSO, out CuttingRecipeSO cuttingRecipeSO))
            {
                int cuttingCount = cuttingRecipeSO.cuttingCount;
                Cut(cuttingCount);
                if (curCuttingCount >= cuttingCount)
                {
                    DestroyFoodMaterialOnHolder();
                    CreateFoodMaterialOnHolder(cuttingRecipeSO.outputFood.foodPrefab);
                }
            }
        }
    }

    private void Cut(int cuttingCount)
    {
        curCuttingCount++;
        _cuttingCounterVisual.playCut();
        _cuttingProgress.UpdateProgress((float)curCuttingCount/cuttingCount);
    }
}
