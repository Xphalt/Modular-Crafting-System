using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace ModularCraftingSystem
{
    public class DynamicInventoryDisplayUI : InventoryDisplayUI
    {
        [SerializeField] protected InventorySlotUI inventorySlot;

        protected override void Start()
        {
            base.Start();
        }

        public void RefreshDynamicInventory(InventorySystem _inventorySystem)
        {
            ClearSlots();
            inventorySystem = _inventorySystem;
            AssignSlot(_inventorySystem);
        }

        public override void AssignSlot(InventorySystem _inventorySystemToDisplay)
        {
            inventorySlotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

            for (int i = 0; i < _inventorySystemToDisplay.GetInventorySize; i++)
            {
                var uiSlot = Instantiate(inventorySlot, transform);
                inventorySlotDictionary.Add(uiSlot, _inventorySystemToDisplay.GetInventorySlots[i]);
                uiSlot.InitialiseSlot(_inventorySystemToDisplay.GetInventorySlots[i]);
                uiSlot.UpdateUISlot();
            }
        }

        private void ClearSlots()
        {
            foreach (var item in transform.Cast<Transform>())
            {
                Destroy(item.gameObject);
            }

            if (GetInventorySlotDictionary != null) { GetInventorySlotDictionary.Clear(); }
        }
    }
}