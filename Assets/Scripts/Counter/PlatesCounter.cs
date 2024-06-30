using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO _plateSO; 
    [SerializeField] private int maxPlatesNum = 6;
    [SerializeField]private float spawnRate = 10;
    
    private float _timer = 0;
    private List<FoodMaterial> _plateList = new List<FoodMaterial>();

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            SpawnPlate();
        }
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > spawnRate && _plateList.Count < maxPlatesNum)
        {
            SpawnPlate();
            _timer = 0;
        }
    }
    //todo 弄清楚为什么不能用transfer的写法
    public void SpawnPlate()
    {
        FoodMaterial plate = GameObject.Instantiate(_plateSO.foodPrefab, GetHoldPoint()).GetComponent<FoodMaterial>();
        //SetHoldingFood(plate);
        plate.transform.localPosition =Vector3.zero + Vector3.up * 0.1f * _plateList.Count;
        _plateList.Add(plate);
    }

    public override void Interact(Player player)
    {
        if (!player.IsHoldingFood() && _plateList.Count != 0)
        {
            player.PutFoodOnHolder(_plateList[_plateList.Count-1]);
            _plateList.RemoveAt(_plateList.Count - 1);
        }
    }
}
