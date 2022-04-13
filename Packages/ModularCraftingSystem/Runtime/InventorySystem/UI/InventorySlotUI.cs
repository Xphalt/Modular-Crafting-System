using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ModularCraftingSystem
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TMP_Text itemCount;
        [SerializeField] private InventorySlot assignedInventorySlot;

        private Button button;

        public InventorySlot GetAssignedInventorySlot => assignedInventorySlot;
        public InventoryDisplayUI GetInventoryDisplay { get; private set; }

        private void Awake()
        {
            ClearSlot();

            button = GetComponent<Button>();
            button?.onClick.AddListener(OnUISlotClick);
            GetInventoryDisplay = transform.parent.GetComponent<InventoryDisplayUI>();
        }

        public void InitialiseSlot(InventorySlot _slot)
        {
            assignedInventorySlot = _slot;
            UpdateUISlot(_slot);
        }

        public void UpdateUISlot(InventorySlot _slot)
        {
            if (_slot.GetItemData != null)
            {
                itemSprite.sprite = _slot.GetItemData.icon;
                itemSprite.color = Color.white;

                if (_slot.GetStackSize > 1) { itemCount.text = _slot.GetStackSize.ToString(); }
                else { itemCount.text = ""; }
            }

            else { ClearSlot(); }

        }

        public void UpdateUISlot()
        {
            if (assignedInventorySlot.GetItemData != null) { UpdateUISlot(assignedInventorySlot); }
        }

        public void ClearSlot()
        {
            assignedInventorySlot?.ClearSlot();
            itemSprite.sprite = null;
            itemSprite.color = Color.clear;
            itemCount.text = "";
        }

        public void OnUISlotClick()
        {
            GetInventoryDisplay?.SlotClicked(this);
        }
    }
}