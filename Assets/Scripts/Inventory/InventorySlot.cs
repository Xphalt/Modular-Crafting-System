using UnityEngine;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private InventoryItemData itemData;
        [SerializeField] private int stackSize;

        public InventoryItemData GetItemData => itemData;
        public int StackSize => stackSize;

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
            stackSize = -1;
        }

        public bool SpaceInStack(int _amountToAdd)
        {
            if (stackSize + _amountToAdd <= itemData.maxStackSize) { return true; }
            else return false;
        }

        public bool SpaceInStack(int _amountToAdd, out int _amountRemaining)
        {
            _amountRemaining = itemData.maxStackSize - stackSize;
            return SpaceInStack(_amountToAdd);
        }


        public void AddToStack(int _amount)
        {
            stackSize += _amount;
        }

        public void RemoveFromStack(int _amount)
        {
            stackSize -= _amount;
        }
    }
}