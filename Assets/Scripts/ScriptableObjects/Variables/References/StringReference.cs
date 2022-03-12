namespace ModularCraftingSystem
{
    [System.Serializable]
    public class StringReference
    {
        public bool useConstant = true;
        public string constantValue;
        public StringVariable variable;

        public string Value
        {
            get { return useConstant ? constantValue : variable.value; }
        }
    }
}