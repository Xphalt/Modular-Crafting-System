using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    public abstract class InventoryDisplayUI : MonoBehaviour
    {
        [SerializeField] HoldItemSlotUI holdItemSlot;

        protected InventorySystem inventorySystem;
        protected Dictionary<InventorySlotUI, InventorySlot> inventorySlotDictionary;
        
        public InventorySystem GetInventorySystem => inventorySystem;
        public Dictionary<InventorySlotUI, InventorySlot> GetInventorySlotDictionary => inventorySlotDictionary;

        public abstract void AssignSlot(InventorySystem _inventorySystemToDisplay);

        protected virtual void Start() { }
        protected virtual void UpdateSlot(InventorySlot _updatedSlot)
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

            // If clicked slot has item but temp doesn't
            if (_clickedSlot.GetAssignedInventorySlot.GetItemData != null && holdItemSlot.holdAssignedInventorySlot.GetItemData == null)
            {
                // If alt key is being pressed, split stack
                if (bIsAltKeyPressed && _clickedSlot.GetAssignedInventorySlot.SplitStack(out InventorySlot _halfStackSlot))
                {
                    holdItemSlot.UpdateTempSlot(_halfStackSlot);
                    _clickedSlot.UpdateUISlot();

                    return;
                }

                else
                {
                    holdItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);
                    _clickedSlot.ClearSlot();

                    return;
                }

            }

            // If clicked slot doesn't have item but temp does
            if (_clickedSlot.GetAssignedInventorySlot.GetItemData == null && holdItemSlot.holdAssignedInventorySlot.GetItemData != null)
            {

                _clickedSlot.GetAssignedInventorySlot.AssignItem(holdItemSlot.holdAssignedInventorySlot);
                _clickedSlot.UpdateUISlot();

                holdItemSlot.ClearSlot();

                return;
            }


            if (_clickedSlot.GetAssignedInventorySlot.GetItemData != null && holdItemSlot.holdAssignedInventorySlot.GetItemData != null)
            {
                bool bIsSameItem = _clickedSlot.GetAssignedInventorySlot.GetItemData == holdItemSlot.holdAssignedInventorySlot.GetItemData;

                if (!bIsSameItem && _clickedSlot.GetAssignedInventorySlot.SpaceInStack(holdItemSlot.holdAssignedInventorySlot.GetStackSize))
                {
                    _clickedSlot.GetAssignedInventorySlot.AssignItem(holdItemSlot.holdAssignedInventorySlot);
                    _clickedSlot.UpdateUISlot();
                    holdItemSlot.ClearSlot();

                    return;
                }

                else if (bIsSameItem && !_clickedSlot.GetAssignedInventorySlot.SpaceInStack(holdItemSlot.holdAssignedInventorySlot.GetStackSize, out int leftInStack))
                {
                    if (leftInStack < 1) { SwapSlots(_clickedSlot); }

                    else
                    {
                        int remainingTemp = holdItemSlot.holdAssignedInventorySlot.GetStackSize - leftInStack;
                        _clickedSlot.GetAssignedInventorySlot.AddToStack(leftInStack);
                        _clickedSlot.UpdateUISlot();

                        var newItem = new InventorySlot(holdItemSlot.holdAssignedInventorySlot.GetItemData, remainingTemp);
                        holdItemSlot.ClearSlot();
                        holdItemSlot.UpdateTempSlot(newItem);

                        return;
                    }
                }

                else if (!bIsSameItem)
                {
                    SwapSlots(_clickedSlot);

                    return;
                }
            }
        }

        private void SwapSlots(InventorySlotUI _clickedSlot)
        {
            var clonedSlot = new InventorySlot(holdItemSlot.holdAssignedInventorySlot.GetItemData, holdItemSlot.holdAssignedInventorySlot.GetStackSize);

            holdItemSlot.ClearSlot();
            holdItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);

            _clickedSlot.ClearSlot();
            _clickedSlot.GetAssignedInventorySlot.AssignItem(clonedSlot);
            _clickedSlot.UpdateUISlot();
        }
    }
}