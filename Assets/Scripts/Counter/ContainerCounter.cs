using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO _foodSO;
    [SerializeField] private CountainerCounterVisual _countainerCounterVisual;
    // Start is called before the first frame update
    void Start()
    {
        //_countainerCounterVisual = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public FoodMaterialSO GetFoodSO()
    {
        return _foodSO;
    }
    
    public void CreateFoodMaterialOnHolder(GameObject foodMaterialPrefab)
    {
        FoodMaterial food = GameObject.Instantiate(foodMaterialPrefab, GetHoldPoint()).GetComponent<FoodMaterial>();
        SetHoldingFood(food);
    }
    public override void Interact(Player player)
    {
        if (player.IsHoldingFood()) return;
        _countainerCounterVisual.PlayOpen();
        CreateFoodMaterialOnHolder(_foodSO.foodPrefab);
        FoodMaterialTransfer(this,player);
    }
}
