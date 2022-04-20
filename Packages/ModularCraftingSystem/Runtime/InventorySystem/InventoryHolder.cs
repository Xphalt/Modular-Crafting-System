using UnityEngine;
using UnityEngine.Events;

namespace ModularCraftingSystem
{
    [System.Serializable]
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem inventorySystem;
        public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

        public InventorySystem GetInventorySystem => inventorySystem;

        private void Awake()
        {
            inventorySystem = new InventorySystem(inventorySize);
        }
    }
}