namespace RfrmLib.Data.Models
{
    internal class ItemInput
    {
        public string Name { get; }
        public string Surname { get; }
        public string Amount { get; }
        public string Mount { get; }

        #region .ctors
        public ItemInput(string name, string surname, string amount, string mount)
        {
            Name = name;
            Surname = surname;
            Amount = amount;
            Mount = mount;
        }
        #endregion
    }
}
