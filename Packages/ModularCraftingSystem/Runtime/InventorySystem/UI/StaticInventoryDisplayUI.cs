using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class StaticInventoryDisplayUI : InventoryDisplayUI
    {
        [SerializeField] private InventoryHolder inventoryHolder;
        [SerializeField] private InventorySlotUI[] slots;

        protected override void Start()
        {
            base.Start();

            if (inventoryHolder != null)
            {
                inventorySystem = inventoryHolder.GetInventorySystem;
                inventorySystem.onInventorySlotChanged += UpdateSlot;
            }

            else { Debug.LogWarning($"No inventory assigned to: {this.gameObject}"); }

            AssignSlot(inventorySystem);
        }
        public override void AssignSlot(InventorySystem _inventory)
        {
            inventorySlotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

            if (slots.Length != inventorySystem.GetInventorySize) { Debug.LogWarning($"Inventory slots dont match inventory size! {this.gameObject} will not be added."); }

            for(int i = 0; i < inventorySystem.GetInventorySize; i++)
            {
                inventorySlotDictionary.Add(slots[i], inventorySystem.GetInventorySlots[i]);
                slots[i].InitialiseSlot(inventorySystem.GetInventorySlots[i]);
            }

        }
    }
}