using UnityEngine;

namespace DefaultNamespace
{
    
    public class BaseCounter:FoodMaterialHolder
    {
        [SerializeField] private GameObject _selectedCounter;
        
        void Start()
        {
            _selectedCounter.SetActive(false);
        }

        public void SelectCounter()
        {
            _selectedCounter.SetActive(true);
        }
        public void CancelSelectedCounter()
        {
            _selectedCounter.SetActive(false);
        }
        
        public virtual void Interact(Player player)
        {
            Debug.LogWarning("There is no override Interact function");
        }
        public void CreateFoodMaterialOnHolder(GameObject foodMaterialPrefab)
        {
            FoodMaterial food = GameObject.Instantiate(foodMaterialPrefab, GetHoldPoint()).GetComponent<FoodMaterial>();
            SetHoldingFood(food);
        }
        public virtual void Operate(Player player)
        {
        }
    }
    
}