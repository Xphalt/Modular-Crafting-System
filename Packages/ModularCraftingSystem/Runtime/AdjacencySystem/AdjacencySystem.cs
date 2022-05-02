using UnityEngine;

namespace ModularCraftingSystem
{
    public class AdjacencySystem : MonoBehaviour
    {
        public CraftingSystem craftingSystem;

        private void Update()
        {
            foreach (InventorySlotUI item in craftingSystem.GetGridSlots)
            {
                
            }
        }
    }
}