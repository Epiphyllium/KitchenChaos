using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    public enum StoveStatus
    {
        Idle,
        Grilling,
        Burning,
        Fire
    }
    [SerializeField] private GrillingRecipeSOList _grillingRecipeSOList;
    [SerializeField] private StoveCounterVisual _stoveCounterVisual;
    [SerializeField] private ProgressBarUI _progressBar;
    
    private float _grillingTimer;
    private GrillingRecipeSO _curGrillingRecipeSO;
    private StoveStatus _state = StoveStatus.Idle;
    public override void Interact(Player player) 
    {
        if (player.IsHoldingFood()&&!IsHoldingFood())
        {
            var food = player.GetHoldingFood();
            if (_grillingRecipeSOList.TryGetGrillingRecipeSO(food.GetFoodMaterialSO(),
                    out _curGrillingRecipeSO))
            {
                FoodMaterialTransfer(player,this);
                Grill();
                return;
            }
        }

        if (!player.IsHoldingFood() && this.IsHoldingFood())
        {
            FoodMaterialTransfer(this,player);
            _state = StoveStatus.Idle;
            return;
        }
    }

    public void Update()
    {
         switch (_state)
        {
            case StoveStatus.Idle:
                _curGrillingRecipeSO = null;
                _stoveCounterVisual.HideStoveEffect();
                _progressBar.Hide();
                break;
            case StoveStatus.Grilling:
                _grillingTimer += Time.deltaTime;
                _progressBar.UpdateProgress(_grillingTimer/_curGrillingRecipeSO.cookingTime);
                if (_grillingTimer >= _curGrillingRecipeSO.cookingTime)
                {
                    DestroyFoodMaterialOnHolder();
                    var curFood = _curGrillingRecipeSO.outputFood;
                    CreateFoodMaterialOnHolder(curFood.foodPrefab);
                    _grillingRecipeSOList.TryGetGrillingRecipeSO(curFood, out _curGrillingRecipeSO);
                    Burning();
                }
                break;
            case StoveStatus.Burning:
                _grillingTimer += Time.deltaTime;
                _progressBar.UpdateProgress(_grillingTimer/_curGrillingRecipeSO.cookingTime);
                if (_grillingTimer >= _curGrillingRecipeSO.cookingTime)
                {
                    DestroyFoodMaterialOnHolder();
                    CreateFoodMaterialOnHolder(_curGrillingRecipeSO.outputFood.foodPrefab);
                    _state = StoveStatus.Fire;
                }
                break;
            case StoveStatus.Fire:
                break;
            default:
                break;
        }
    }

    private void Grill()
    {
        _grillingTimer = 0.0f;
        _state = StoveStatus.Grilling;
        _stoveCounterVisual.ShowStoveEffect();
    }
    private void Burning()
    {
        _grillingTimer = 0.0f;
        _state = StoveStatus.Burning;
        _stoveCounterVisual.ShowStoveEffect();
    }
}
