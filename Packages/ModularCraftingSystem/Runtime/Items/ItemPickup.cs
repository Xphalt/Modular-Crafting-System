using UnityEngine;

namespace ModularCraftingSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class ItemPickup : MonoBehaviour
    {
        public float pickupRadius = 1f;
        public InventoryItemData itemData;

        private SphereCollider sphereCollider;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
            sphereCollider.radius = pickupRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            var inventory = other.transform.GetComponent<InventoryHolder>();

            if (!inventory) { return; }

            if (inventory.GetInventorySystem.AddToInventory(itemData, 1))
            {
                Destroy(this.gameObject);
            }
        }
    }
}