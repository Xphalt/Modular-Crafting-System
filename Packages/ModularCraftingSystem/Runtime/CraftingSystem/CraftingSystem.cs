using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class CraftingSystem : MonoBehaviour
    {
        public Transform craftingSlotTransform;
        public InventorySlotUI outputSlot;
        [SerializeField] private int gridSize;
        [SerializeField] private List<InventorySlotUI> listOfinventorySlotUIs;
        [SerializeField] private List<CraftingRecipeData> listOfRecipes;
        //public CraftingRecipeData recipe;

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

        public void Update()
        {
            InventoryResourceData craftingResult = null;

            craftingResult = LoopThroughRecipes();
            CreateOutput(craftingResult);
        }

        public void CreateOutput(InventoryResourceData craftingResult)
        {
            outputSlot.GetAssignedInventorySlot.UpdateInventorySlot(craftingResult, 1);
            outputSlot.UpdateUISlot();
            
        }

        private InventoryResourceData LoopThroughRecipes()
        {
            InventoryResourceData craftingResult = null;

            foreach (CraftingRecipeData recipe in listOfRecipes)
            {
                craftingResult = LoopThroughSlots(recipe);

                if (craftingResult == null) { break; }
            }

            return craftingResult;
        }

        private InventoryResourceData LoopThroughSlots(CraftingRecipeData recipe)
        {
            InventoryResourceData craftingResult = null;

            for (int i = 0; i < gridSize; i++)
            {
                craftingResult = DoesSlotItemMatchRecipe(recipe, i);

                if (!craftingResult) { return null; }
            }

            return craftingResult;
        }

        private InventoryResourceData DoesSlotItemMatchRecipe(CraftingRecipeData recipe, int i)
        {
            if (/*listOfinventorySlotUIs.ToArray()[i].GetAssignedInventorySlot.GetItemData != null &&*/
                listOfinventorySlotUIs.ToArray()[i].GetAssignedInventorySlot.GetItemData != recipe.listOfComponents.ToArray()[i])
            {
                return null;
            }

            return recipe.GetOutput();
        }
    }
}
