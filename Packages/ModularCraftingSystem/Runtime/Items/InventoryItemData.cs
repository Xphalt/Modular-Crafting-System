using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    [CreateAssetMenu(menuName = "Modular Crafting System/Inventory/Item", fileName = "NewInventoryItem")]
    public class InventoryItemData : ScriptableObject
    {
        public Sprite icon;
        public int maxStackSize;

        [SerializeField] List<InventoryItemAttribute> listOfAttribute = new List<InventoryItemAttribute>();
    }
}