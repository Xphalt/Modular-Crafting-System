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
        public CraftingRecipeData recipe;

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

        private void Update()
        {
            CheckSlotMatchesRecipe();
        }

        public void CheckSlotMatchesRecipe()
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (listOfinventorySlotUIs.ToArray()[i].GetAssignedInventorySlot.GetItemData != null &&
                    listOfinventorySlotUIs.ToArray()[i].GetAssignedInventorySlot.GetItemData == recipe.listOfComponents.ToArray()[i])
                {
                    Debug.Log("Y");
                }
            }
        }
    }
}
