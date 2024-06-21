using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.IsHoldingFood()&&!IsHoldingFood())
        {
            FoodMaterialTransfer(player,this);
            return;
        }

        if (!player.IsHoldingFood() && this.IsHoldingFood())
        {
            FoodMaterialTransfer(this,player);
            return;
        }
    }
}
