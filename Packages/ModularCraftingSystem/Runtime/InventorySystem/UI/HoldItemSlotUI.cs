using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace ModularCraftingSystem
{
    public class HoldItemSlotUI : MonoBehaviour
    {
        public Image itemSprite;
        public TMP_Text itemCount;
        public InventorySlot holdAssignedInventorySlot;

        private void Awake()
        {
            itemSprite.color = Color.clear;
            itemCount.text = "";
        }

        public void UpdateTempSlot(InventorySlot _slot)
        {
            holdAssignedInventorySlot.AssignItem(_slot);
            itemSprite.sprite = _slot.GetItemData.icon;
            itemCount.text = _slot.GetStackSize.ToString();
            itemSprite.color = Color.white;
        }

        private void Update()
        {
            if(holdAssignedInventorySlot.GetItemData != null)
            {
                transform.position = Mouse.current.position.ReadValue();
            
                if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject()) { ClearSlot(); }
            }
        }

        public void ClearSlot()
        {
            holdAssignedInventorySlot.ClearSlot();
            itemCount.text = "";
            itemSprite.color = Color.clear;
            itemSprite.sprite = null;
        }

        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results.Count > 0;
        }

    }
}