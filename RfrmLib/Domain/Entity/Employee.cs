using System.Collections.Generic;

namespace RfrmLib.Domain.Entity
{
    public class Employee
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Salary> Salaries { get; set; }
        public string SalarySum { get; set; }

        #region .ctors
        public Employee(string name, string surname, List<Salary> salaries = default)
        {
            Name = name;
            Surname = surname;
            Salaries = salaries ?? [];
        }
        #endregion
    }
}
