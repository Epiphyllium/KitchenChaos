using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable][CreateAssetMenu]
    public class FoodMaterialSO: ScriptableObject
    {
        public GameObject foodPrefab;
        public Sprite sprite;
        public string name;
    }
}