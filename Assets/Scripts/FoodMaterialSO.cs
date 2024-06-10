using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class FoodMaterialSO: ScriptableObject
    {
        public GameObject foodPrefab;
        public Sprite sprite;
        public string name;
    }
}