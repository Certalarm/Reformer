using System.Collections.Generic;

namespace RfrmLib.Data.Models
{
    internal class EmployeeInput
    {
        public string Name { get; }
        public string Surname { get; }
        public List<SalaryInput> Salaries { get; set; }

        #region .ctors
        public EmployeeInput(string name, string surname, List<SalaryInput> salaries = default)
        {
            Name = name;
            Surname = surname;
            Salaries = salaries ?? [];
        }
        #endregion
    }
}
