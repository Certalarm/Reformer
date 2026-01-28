namespace RfrmLib.Data.Models
{
    internal class SalaryInput
    {
        public string Amount { get; }
        public string Mount { get; }

        #region .ctors
        public SalaryInput(string amount, string mount)
        {
            Amount = amount;
            Mount = mount;
        }
        #endregion
    }
}
