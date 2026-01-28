using System.Collections.Generic;
using System.Linq;

namespace RfrmLib.Domain.Entity
{
    public class Employee
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Salary> Salaries { get; set; }
        public double SalarySum => GetSalarySum();

        #region .ctors
        public Employee(string name, string surname, List<Salary> salaries = default)
        {
            Name = name;
            Surname = surname;
            Salaries = salaries ?? [];
        }
        #endregion

        private double GetSalarySum() =>
            Salaries
                .Sum(x => x.Amount);
    }
}
