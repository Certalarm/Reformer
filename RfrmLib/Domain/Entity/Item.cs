namespace RfrmLib.Domain.Entity
{
    internal class Item
    {
        public string Name { get; }
        public string Surname { get; }
        public double Amount { get; }
        public string Mount { get; }

        #region .ctors
        public Item(string name, string surname, double amount, string mount)
        {
            Name = name;
            Surname = surname;
            Amount = amount;
            Mount = mount;
        }
        #endregion
    }
}
