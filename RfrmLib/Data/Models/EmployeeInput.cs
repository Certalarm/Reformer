using System.Collections.Generic;

namespace RfrmLib.Data.Models
{
    public class EmployeeInput
    {
        public string Name { get; }
        public string Surname { get; }
        public IList<SalaryInput> Salaries { get; set; }

        #region .ctors
        public EmployeeInput(string name, string surname, IList<SalaryInput> salaries = default)
        {
            Name = name;
            Surname = surname;
            Salaries = salaries ?? [];
        }
        #endregion
    }
}
