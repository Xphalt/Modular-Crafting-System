using UnityEngine;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private InventoryItemData itemData;
        [SerializeField] private int stackSize;

        public InventoryItemData GetItemData => itemData;
        public int GetStackSize => stackSize;

        public InventorySlot(InventoryItemData _source, int _amount)
        {
            itemData = _source;
            stackSize = _amount;
        }

        public InventorySlot()
        {
            ClearSlot();
        }

        public void UpdateInventorySlot(InventoryItemData _data, int _amount)
        {
            itemData = _data;
            stackSize = _amount;
        }

        public void ClearSlot()
        {
            itemData = null;
            stackSize = 0;
        }

        public void AssignItem(InventorySlot _slot)
        {
            if (itemData == _slot.itemData) { AddToStack(_slot.stackSize); }

            else
            {
                itemData = _slot.itemData;
                stackSize = 0;
                AddToStack(_slot.stackSize);
            }
        }

        public bool SpaceInStack(int _amountToAdd, out int _amountRemaining)
        {
            _amountRemaining = itemData.maxStackSize - stackSize;
            return SpaceInStack(_amountToAdd);
        }

        public bool SpaceInStack(int _amountToAdd)
        {
            if (itemData == null || itemData != null && stackSize + _amountToAdd <= itemData.maxStackSize) { return true; }
            else { return false; }
        }

        public void AddToStack(int _amount)
        {
            stackSize += _amount;
        }

        public void RemoveFromStack(int _amount)
        {
            stackSize -= _amount;
        }

        public bool SplitStack(out InventorySlot _splitStack)
        {
            if (stackSize <= 1)
            {
                _splitStack = null;

                return false;
            }

            int halfStack = Mathf.RoundToInt(stackSize / 2);
            RemoveFromStack(halfStack);
            _splitStack = new InventorySlot(itemData, halfStack);

            return true;
        }
    }
}