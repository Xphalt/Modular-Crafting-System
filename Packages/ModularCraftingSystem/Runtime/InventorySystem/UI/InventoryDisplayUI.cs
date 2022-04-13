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
            if ((_clickedSlot.GetAssignedInventorySlot.GetItemData != null) && (temporaryItemSlot.tempAssignedInventorySlot.GetItemData == null))
            {
                temporaryItemSlot.UpdateTempSlot(_clickedSlot.GetAssignedInventorySlot);
                _clickedSlot.ClearSlot();

                return;
            }
        }
    }
}
