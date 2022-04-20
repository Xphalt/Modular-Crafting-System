using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Inventory/Resource", fileName = "NewInventoryResource")]
    public class InventoryResourceData : ScriptableObject
    {
        public Sprite icon;
        public int maxStackSize;
    }
}