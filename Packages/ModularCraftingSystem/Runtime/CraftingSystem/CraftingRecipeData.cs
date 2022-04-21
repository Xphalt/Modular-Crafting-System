using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Crafting/Recipe", fileName = "NewCraftingRecipe")]
    public class CraftingRecipeData : ScriptableObject
    {
        public InventoryResourceData item1;
        public InventoryResourceData item2;
        public InventoryResourceData item3;
        public InventoryResourceData item4;
        public InventoryResourceData item5;
        public InventoryResourceData item6;
        public InventoryResourceData item7;
        public InventoryResourceData item8;
        public InventoryResourceData item9;
        public InventoryResourceData outputItem;
    }
}