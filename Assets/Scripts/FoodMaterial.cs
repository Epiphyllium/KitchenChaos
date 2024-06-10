using UnityEngine;

namespace DefaultNamespace
{
    public class FoodMaterial : MonoBehaviour
    {
        [SerializeField] private FoodMaterialSO _foodSO;

        public FoodMaterialSO GetFoodMaterialSO()
        {
            return _foodSO;
        }
    }
}