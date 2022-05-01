using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Crafting/Recipe", fileName = "NewCraftingRecipe")]
    public class CraftingRecipeData : ScriptableObject
    {
        public InventoryItemData item1;
        public InventoryItemData item2;
        public InventoryItemData item3;
        public InventoryItemData item4;
        public InventoryItemData item5;
        public InventoryItemData item6;
        public InventoryItemData item7;
        public InventoryItemData item8;
        public InventoryItemData item9;
        public InventoryItemData outputItem;

        public List<InventoryItemData> listOfComponents;

        private void Awake()
        {
            listOfComponents.Add(item1);
            listOfComponents.Add(item2);
            listOfComponents.Add(item3);
            listOfComponents.Add(item4);
            listOfComponents.Add(item5);
            listOfComponents.Add(item6);
            listOfComponents.Add(item7);
            listOfComponents.Add(item8);
            listOfComponents.Add(item9);
        }

        public InventoryItemData GetOutput() { return outputItem; }
    }
}