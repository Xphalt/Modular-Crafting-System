using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Variables/String", fileName = "NewStringVariable")]
    public class StringVariable : ScriptableObject
    {
        public string value;
    }
}