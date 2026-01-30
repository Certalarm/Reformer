using RfrmLib.Data.Models;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RfrmLib.Data.Mapper
{
    public static class EmployeeInputMapper
    {
        public static Employee ToDomain(this EmployeeInput employee) =>
            new(employee.Name, employee.Surname, ToDomain(employee.Salaries));

        private static List<Salary> ToDomain(IList<SalaryInput> salaries) =>
            salaries
                .Select(x => x.ToDomain())
                .ToList();

        private static Salary ToDomain(this SalaryInput salary) =>
            new(salary.Amount, salary.Mount);
    }
}
