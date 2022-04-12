using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    public abstract class InventoryDisplay : MonoBehaviour
    {

        protected InventorySystem inventorySystem;
        protected Dictionary<InventorySlotUI, InventorySlot> inventorySlotDictionary;

        public InventorySystem GetInventorySystem => inventorySystem;
        public Dictionary<InventorySlotUI, InventorySlot> GetInventoryDictionary => inventorySlotDictionary;

        public abstract void AssignSlots(InventorySystem _inventory);

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
            Debug.Log("Slot clicked!");
        }
    }
}
