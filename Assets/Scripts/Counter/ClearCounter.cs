using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class ClearCounter : BaseCounter
{
    
    [SerializeField] private bool isTesting = false;
    
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (isTesting && Input.GetMouseButtonDown(0))
        {
            FoodMaterialTransfer(this,GetTargetHolder());
        }
    }
    
    public override void Interact(Player player)
    {
        // FoodMaterial food = GetHoldingFood();
        // if (food == null)
        // {
        //     food = GameObject.Instantiate(GetFoodSO().foodPrefab, GetHoldPoint()).GetComponent<FoodMaterial>();
        //     SetHoldingFood(food);
        // }
        // else
        // {
        //     FoodMaterialTransfer(this,player);
        // }
    }
    
    
}
