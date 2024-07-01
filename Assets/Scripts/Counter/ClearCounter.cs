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
        if (player.IsHoldingFood())
        {
            var playerIsHoldingPlate = player.GetHoldingFood().TryGetComponent<Plate>(out Plate plateOnPlayer);
            if (playerIsHoldingPlate) //player is holding a plate
            {
                Debug.Log("Holding Plates");
                if (!this.IsHoldingFood()) // counter is empty
                {
                    FoodMaterialTransfer(player,this);
                    return;
                }
                 //there are food material on counter
                if (plateOnPlayer.TryAddFoodMaterial(this.GetHoldingFoodSO()))
                {
                    DestroyFoodMaterialOnHolder();
                }
                return;
            }
            
            //player is not holding plate
            if (!this.IsHoldingFood())
            {
                FoodMaterialTransfer(player,this);
                return;
            }
            
            //The counter is not Empty
            bool counterIsHoldingPlate = this.GetHoldingFood().TryGetComponent<Plate>(out Plate plateOnCounter);
            if (counterIsHoldingPlate)
            {
                if (plateOnCounter.TryAddFoodMaterial(player.GetHoldingFoodSO()))
                {
                    player.DestroyFoodMaterialOnHolder();
                    return;
                }
            }
        }

        if (!player.IsHoldingFood() && this.IsHoldingFood())
        {
            FoodMaterialTransfer(this,player);
            return;
        }
    }
    
    
}
