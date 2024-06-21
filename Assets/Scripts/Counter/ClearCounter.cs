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
