using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem inventorySystem;

        public InventorySystem GetInventorySystem => inventorySystem;

        public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

        private void Awake()
        {
            inventorySystem = new InventorySystem(inventorySize);
        }
    }
}