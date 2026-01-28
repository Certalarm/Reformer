namespace RfrmLib.Data.Models
{
    internal class EmployeeInput
    {
        public string Name { get; }
        public string Surname { get; }

        #region .ctors
        public EmployeeInput(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        #endregion
    }
}
