namespace RfrmLib.Domain.Entity
{
    public class Salary
    {
        public double Amount { get; }
        public string Mount { get; }

        #region .ctors
        public Salary(double amount, string mount)
        {
            Amount = amount;
            Mount = mount;
        }
        #endregion
    }
}
