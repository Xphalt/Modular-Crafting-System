using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    public class InventoryUIController : MonoBehaviour
    {
        public DynamicInventoryDisplayUI inventoryPanel;
        public int gridSize;

        private void Awake()
        {
            inventoryPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        }


        private void OnDisable()
        {
            InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        }
        private void DisplayInventory(InventorySystem _inventoryToDisplay)
        {
            inventoryPanel.gameObject.SetActive(true);
            inventoryPanel.RefreshDynamicInventory(_inventoryToDisplay);
        }

        void Update()
        {
            if (!inventoryPanel.gameObject.activeInHierarchy && Keyboard.current.eKey.wasPressedThisFrame)
            {
                DisplayInventory(new InventorySystem(gridSize));
            }

            if (inventoryPanel.gameObject.activeInHierarchy && Keyboard.current.eKey.wasPressedThisFrame)
            {
                inventoryPanel.gameObject.SetActive(false);
            }
        }
    }
}