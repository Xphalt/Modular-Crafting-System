using UnityEngine;

namespace ModularCraftingSystem
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Modular Crafting System/Resources/New Resource", fileName = "NewResource")]
    public class Resource : ScriptableObject
    {
        public StringReference resourceName;
        public FloatReference resourceWeight;
        public FloatReference resourceToughness;
    }
}