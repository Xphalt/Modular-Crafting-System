using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Inventory/Attribute", fileName = "NewInventoryAttribute")]
    public class InventoryItemAttribute : ScriptableObject
    {
        public float value;
    }
}