using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    public class OutputSlot : MonoBehaviour
    {
        [SerializeField] HoldItemSlotUI holdItemSlot;
        [SerializeField] private InventoryHolder inventoryHolder;
        [SerializeField] private InventorySlotUI[] slots;
        public CraftingSystem craftingSystem;

        private InventorySystem inventorySystem;
        private Dictionary<InventorySlotUI, InventorySlot> inventorySlotDictionary;

        private InventorySystem GetInventorySystem => inventorySystem;
        private Dictionary<InventorySlotUI, InventorySlot> GetInventorySlotDictionary => inventorySlotDictionary;

        private void Start()
        {
            if (inventoryHolder != null)
            {
                inventorySystem = inventoryHolder.GetInventorySystem;
                inventorySystem.onInventorySlotChanged += UpdateSlot;
            }

            else { Debug.LogWarning($"No inventory assigned to: {this.gameObject}"); }

            AssignSlot(inventorySystem);
        }

        private void AssignSlot(InventorySystem _inventorySystemToDisplay)
        {
            inventorySlotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

            if (slots.Length != inventorySystem.GetInventorySize) { Debug.LogWarning($"Inventory slots dont match inventory size! {this.gameObject} will not be added."); }

            for (int i = 0; i < inventorySystem.GetInventorySize; i++)
            {
                inventorySlotDictionary.Add(slots[i], inventorySystem.GetInventorySlots[i]);
                slots[i].InitialiseSlot(inventorySystem.GetInventorySlots[i]);
            }
        }

        private void UpdateSlot(InventorySlot _updatedSlot)
        {
            foreach (var slot in inventorySlotDictionary)
            {
                if (slot.Value == _updatedSlot)
                {
                    slot.Key.UpdateUISlot(_updatedSlot);
                }
            }
        }

        public void SlotClicked(InventorySlotUI _clickedSlot)
        {
            bool bIsAltKeyPressed = Keyboard.current.leftShiftKey.isPressed;

            // Clicked slot != null | Hold slot == null
            if (_clickedSlot.GetAssignedInventorySlot.GetItemData != null && holdItemSlot.holdAssignedInventorySlot.GetItemData == null)
            {
                // Shortcut key == true
                holdItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);

                foreach (InventorySlotUI item in craftingSystem.GetGridSlots)
                {
                    item.ClearSlot();
                }

                _clickedSlot.ClearSlot();

                return;

            }

            //// Clicked slot == null | Hold slot != null
            //if (_clickedSlot.GetAssignedInventorySlot.GetItemData == null && holdItemSlot.holdAssignedInventorySlot.GetItemData != null)
            //{

            //    _clickedSlot.GetAssignedInventorySlot.AssignItem(holdItemSlot.holdAssignedInventorySlot);
            //    _clickedSlot.UpdateUISlot();

            //    holdItemSlot.ClearSlot();

            //    return;
            //}

            //// Clicked slot != null | Hold slot != null
            //if (_clickedSlot.GetAssignedInventorySlot.GetItemData != null && holdItemSlot.holdAssignedInventorySlot.GetItemData != null)
            //{
            //    bool bIsSameItem = _clickedSlot.GetAssignedInventorySlot.GetItemData == holdItemSlot.holdAssignedInventorySlot.GetItemData;

            //    // Same item == true | Space in stack == true 
            //    if (bIsSameItem && _clickedSlot.GetAssignedInventorySlot.SpaceInStack(holdItemSlot.holdAssignedInventorySlot.GetStackSize))
            //    {
            //        _clickedSlot.GetAssignedInventorySlot.AssignItem(holdItemSlot.holdAssignedInventorySlot);
            //        _clickedSlot.UpdateUISlot();
            //        holdItemSlot.ClearSlot();

            //        return;
            //    }

            //    // Same item == true | Space in stack == false
            //    else if (bIsSameItem && !_clickedSlot.GetAssignedInventorySlot.SpaceInStack(holdItemSlot.holdAssignedInventorySlot.GetStackSize, out int leftInStack))
            //    {
            //        int remainingTemp = holdItemSlot.holdAssignedInventorySlot.GetStackSize - leftInStack;
            //        _clickedSlot.GetAssignedInventorySlot.AddToStack(leftInStack);
            //        _clickedSlot.UpdateUISlot();

            //        var newItem = new InventorySlot(holdItemSlot.holdAssignedInventorySlot.GetItemData, remainingTemp);
            //        holdItemSlot.ClearSlot();
            //        holdItemSlot.UpdateTempSlot(newItem);

            //        return;
            //    }
            //}
        }
    }
}