using UnityEngine;

namespace ModularCraftingSystem
{
    public class Item : ScriptableObject
    {
        private Actions actions;
        private Attributes attributes;

        public Actions primaryAction;
        public Actions secondaryAction;

        private void Awake()
        {
            primaryAction = actions.PrimaryAction();
            secondaryAction = actions.SecondaryAction();
        }
    }
}