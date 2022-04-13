using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventorySystem
    {
        [SerializeField] private List<InventorySlot> inventorySlots;

        public UnityAction<InventorySlot> onInventorySlotChanged;
        public List<InventorySlot> GetInventorySlots => inventorySlots;
        public int GetInventorySize => GetInventorySlots.Count;
        public UnityAction<InventorySlot> GetInventorySlotChanged { get { return onInventorySlotChanged; } set { onInventorySlotChanged = value; } }

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
            if (ContainsItem(_itemToAdd, out List<InventorySlot> _inventorySlot))
            {
                foreach (var slot in _inventorySlot)
                {
                    if (slot.SpaceInStack(_amount))
                    {
                        slot.AddToStack(_amount);
                        onInventorySlotChanged?.Invoke(slot);

                        return true;
                    }
                }
            }

            if (HasFreeSlot(out InventorySlot _freeSlot))
            {
                _freeSlot.UpdateInventorySlot(_itemToAdd, _amount);
                onInventorySlotChanged?.Invoke(_freeSlot);

                return true;
            }

            return false;
        }

        public bool ContainsItem(InventoryItemData _itemData, out List<InventorySlot> _inventorySlot)
        {
            _inventorySlot = inventorySlots.Where(i => i.GetItemData == _itemData).ToList();

            return _inventorySlot == null ? false : true;
        }

        public bool HasFreeSlot(out InventorySlot _freeSlot)
        {
            _freeSlot = inventorySlots.FirstOrDefault(i => i.GetItemData == null);

            return _freeSlot == null ? false : true;
        }
    }
}