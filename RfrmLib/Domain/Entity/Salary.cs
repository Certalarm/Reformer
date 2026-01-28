namespace RfrmLib.Domain.Entity
{
    public class Salary
    {
        public string Amount { get; }
        public string Mount { get; }

        #region .ctors
        public Salary(string amount, string mount)
        {
            Amount = amount;
            Mount = mount;
        }
        #endregion
    }
}
