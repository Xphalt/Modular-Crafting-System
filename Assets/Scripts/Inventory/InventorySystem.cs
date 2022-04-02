using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventorySystem
    {
        [SerializeField] private List<InventorySlot> inventorySlots;
        public int inventorySize => GetInventorySlots.Count;
        public UnityAction<InventorySlot> onInventorySlotChanged;

        public List<InventorySlot> GetInventorySlots => inventorySlots;

        public InventorySystem(int _size)
        {
            inventorySlots = new List<InventorySlot>(_size);

            for (int i = 0; i < _size; i++)
            {
                inventorySlots.Add(new InventorySlot());
            }
        }

        public bool AddToInventory(InventoryItemData _itemToAdd, int _amount)
        {
            inventorySlots[0] = new InventorySlot(_itemToAdd, _amount);
            return true;
        }
    }
}