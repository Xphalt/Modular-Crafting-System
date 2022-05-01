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
        private List<InventoryItemData> listOfGridItem;

        public int GetGridSize => gridSize;
        public List<InventorySlotUI> GetGridSlots => listOfSlots;

        private void Awake()
        {
            gameObject.SetActive(false);

            listOfSlots = new List<InventorySlotUI>();

            for (int i = 0; i < craftingSlotTransform.childCount; i++)
            {
                listOfSlots.Add(craftingSlotTransform.GetChild(i).GetComponent<InventorySlotUI>());
            }

            gridSize = listOfSlots.Count;
        }

        public void Update()
        {
            CheckRecipe();
        }

        private void CheckRecipe()
        {
            listOfGridItem = new List<InventoryItemData>();

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

        private void CreateOutput(InventoryItemData craftingResult)
        {
            outputSlot.GetAssignedInventorySlot.UpdateInventorySlot(craftingResult, 1);
            outputSlot.UpdateUISlot();
        }
    }
}