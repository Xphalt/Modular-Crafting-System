using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Resources/New Resource", fileName = "NewResource")]
    public class Resource : ScriptableObject
    {
        public FloatReference resourceWeight;
        public FloatReference resourceToughness;
    }
}