using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class CraftingSystem : MonoBehaviour
    {
        public Transform craftingSlotTransform;
        public InventorySlotUI outputSlot;
        [SerializeField] private int gridSize;
        [SerializeField] private List<InventorySlotUI> listOfSlots;
        [SerializeField] private List<CraftingRecipeData> listOfRecipes;

        public int GetGridSize => gridSize;

        private void Awake()
        {
            listOfSlots = new List<InventorySlotUI>();

            for (int i = 0; i < craftingSlotTransform.childCount; i++)
            {
                listOfSlots.Add(craftingSlotTransform.GetChild(i).GetComponent<InventorySlotUI>());
            }

            gridSize = listOfSlots.Count;
        }

        public void Update()
        {
            List<InventoryResourceData> listOfGridItem = new List<InventoryResourceData>();

            foreach (InventorySlotUI slot in listOfSlots)
            {
                listOfGridItem.Add(slot.GetAssignedInventorySlot.GetItemData);
            }

            foreach (CraftingRecipeData recipe in listOfRecipes)
            {
                if (listOfGridItem.SequenceEqual(recipe.listOfComponents))
                {
                    CreateOutput(recipe.outputItem);
                }
            }
        }

        public void CreateOutput(InventoryResourceData craftingResult)
        {
            outputSlot.GetAssignedInventorySlot.UpdateInventorySlot(craftingResult, 1);
            outputSlot.UpdateUISlot();
        }
    }
}