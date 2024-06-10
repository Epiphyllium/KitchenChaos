using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class ClearCounter : FoodMaterialHolder
{
    [SerializeField] private GameObject _selectedCounter;
    [SerializeField] private bool isTesting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _selectedCounter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTesting && Input.GetMouseButtonDown(0))
        {
            FoodMaterialTransfer(this,GetTargetHolder());
        }
    }
    
    public void Interact()
    {
        Debug.Log(this.gameObject+" is interacting");
        FoodMaterial food = GetHoldingFood();
        if (food == null)
        {
            food = GameObject.Instantiate(GetFoodSO().foodPrefab, GetHoldPoint()).GetComponent<FoodMaterial>();
            SetHoldingFood(food);
        }
        else
        {
            Debug.LogWarning("There is "+ food.gameObject +" on the holder "+this.gameObject);
        }
    }
    public void SelectCounter()
    {
        _selectedCounter.SetActive(true);
    }
    public void CancelSelectedCounter()
    {
        _selectedCounter.SetActive(false);
    }
    
}
