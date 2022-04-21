using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class CraftingSystem : MonoBehaviour
    {
        public Transform craftingSlotTransform;
        [SerializeField] private int gridSize;
        [SerializeField] private List<InventorySlotUI> inventorySlotUIs;
        private List<CraftingRecipeData> listOfRecipes;

        public int GetGridSize => gridSize;

        private void Awake()
        {
            inventorySlotUIs = new List<InventorySlotUI>();

            for (int i = 0; i < craftingSlotTransform.childCount; i++)
            {
                inventorySlotUIs.Add(craftingSlotTransform.GetChild(i).GetComponent<InventorySlotUI>());
            }

            gridSize = inventorySlotUIs.Count;
        }

        public bool IsSlotFull(InventorySlotUI _inventorySlotUI)
        {
            if (_inventorySlotUI.GetAssignedInventorySlot.GetItemData == null)
            {
                return false;
            }

            return true;
        }
    }
}
