using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class CraftingSystem : MonoBehaviour
    {
        public Transform craftingSlotTransform;
        [SerializeField] private int gridSize;
        [SerializeField] private List<InventorySlotUI> listOfinventorySlotUIs;
        [SerializeField] private List<CraftingRecipeData> listOfRecipes;

        public int GetGridSize => gridSize;

        private void Awake()
        {
            listOfinventorySlotUIs = new List<InventorySlotUI>();

            for (int i = 0; i < craftingSlotTransform.childCount; i++)
            {
                listOfinventorySlotUIs.Add(craftingSlotTransform.GetChild(i).GetComponent<InventorySlotUI>());
            }

            gridSize = listOfinventorySlotUIs.Count;
        }

        public void CheckItemInSlot()
        {
            foreach (InventorySlotUI slot in listOfinventorySlotUIs)
            {
                foreach (CraftingRecipeData recipe in listOfRecipes)
                {
                    foreach (InventoryResourceData item in recipe.listOfComponents)
                    {
                        if (slot.GetAssignedInventorySlot.GetItemData != null && slot.GetAssignedInventorySlot.GetItemData == item)
                        {
                            Debug.Log("Y");
                        }
                    }
                }
            }
        }
    }
}
