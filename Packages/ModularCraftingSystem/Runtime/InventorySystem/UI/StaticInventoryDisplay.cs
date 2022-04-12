using System.Collections.Generic;
using UnityEngine;

namespace ModularCraftingSystem
{
    public class StaticInventoryDisplay : InventoryDisplay
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

            AssignSlots(inventorySystem);
        }
        public override void AssignSlots(InventorySystem _inventory)
        {
            inventorySlotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

            if (slots.Length != inventorySystem.inventorySize) { Debug.LogWarning($"Inventory slots dont match inventory size! {this.gameObject} will not be added."); }

            for(int i = 0; i < inventorySystem.inventorySize; i++)
            {
                inventorySlotDictionary.Add(slots[i], inventorySystem.GetInventorySlots[i]);
                slots[i].InitialiseSlot(inventorySystem.GetInventorySlots[i]);
            }

        }
    }
}