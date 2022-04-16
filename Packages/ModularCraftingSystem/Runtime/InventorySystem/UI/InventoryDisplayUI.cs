using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    public abstract class InventoryDisplayUI : MonoBehaviour
    {
        [SerializeField] TempItemSlotUI temporaryItemSlot;

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

            if (_clickedSlot.GetAssignedInventorySlot.GetItemData != null && temporaryItemSlot.tempAssignedInventorySlot.GetItemData == null)
            {
                if (bIsAltKeyPressed && _clickedSlot.GetAssignedInventorySlot.SplitStack(out InventorySlot _halfStackSlot))
                {
                    temporaryItemSlot.UpdateTempSlot(_halfStackSlot);
                    _clickedSlot.UpdateUISlot();
                    return;
                }

                temporaryItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);
                _clickedSlot.ClearSlot();

                return;
            }

            if (_clickedSlot.GetAssignedInventorySlot.GetItemData == null && temporaryItemSlot.tempAssignedInventorySlot.GetItemData != null)
            {

                _clickedSlot.GetAssignedInventorySlot.AssignItem(temporaryItemSlot.tempAssignedInventorySlot);
                _clickedSlot.UpdateUISlot();

                temporaryItemSlot.ClearSlot();
            }

            bool bIsSameItem = _clickedSlot.GetAssignedInventorySlot.GetItemData == temporaryItemSlot.tempAssignedInventorySlot.GetItemData;

            if (!bIsSameItem && _clickedSlot.GetAssignedInventorySlot.SpaceInStack(temporaryItemSlot.tempAssignedInventorySlot.GetStackSize))
            {
                _clickedSlot.GetAssignedInventorySlot.AssignItem(temporaryItemSlot.tempAssignedInventorySlot);
                _clickedSlot.UpdateUISlot();
                temporaryItemSlot.ClearSlot();

                return;
            }

            else if (bIsSameItem && !_clickedSlot.GetAssignedInventorySlot.SpaceInStack(temporaryItemSlot.tempAssignedInventorySlot.GetStackSize, out int leftInStack))
            {
                if(leftInStack < 1) { SwapSlots(_clickedSlot); }

                else
                {
                    int remainingTemp = temporaryItemSlot.tempAssignedInventorySlot.GetStackSize - leftInStack;
                    _clickedSlot.GetAssignedInventorySlot.AddToStack(leftInStack);
                    _clickedSlot.UpdateUISlot();

                    var newItem = new InventorySlot(temporaryItemSlot.tempAssignedInventorySlot.GetItemData, remainingTemp);
                    temporaryItemSlot.ClearSlot();
                    temporaryItemSlot.UpdateTempSlot(newItem);

                    return;
                }
            }

            else if (!bIsSameItem)
            {
                SwapSlots(_clickedSlot);

                return;
            }
        }

        private void SwapSlots(InventorySlotUI _clickedSlot)
        {
            var clonedSlot = new InventorySlot(temporaryItemSlot.tempAssignedInventorySlot.GetItemData, temporaryItemSlot.tempAssignedInventorySlot.GetStackSize);
            temporaryItemSlot.ClearSlot();
            temporaryItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);
            _clickedSlot.ClearSlot();
            _clickedSlot.GetAssignedInventorySlot.AssignItem(clonedSlot);
            _clickedSlot.UpdateUISlot();
        }
    }
}