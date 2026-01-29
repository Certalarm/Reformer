using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase.GetEmployeesAmounts
{
    public class GetEmployeesAmountsInteractor
    {
        private int _padLen;

        #region .ctors
        public GetEmployeesAmountsInteractor()
        {
        }
        #endregion

        public IEnumerable<string> Execute(IEnumerable<Employee> employees)
        {
            _padLen = GetMaxMountLen(employees);
            foreach (var employee in employees)
                yield return GetEmployeeInfo(employee);
        }

        private string GetEmployeeInfo(Employee employee)
        {
            string fullname = $"{employee.Name}{__space}{employee.Surname}";
            string byMonths = string.Join(__rn, employee.Salaries
                .Select(x => $"{__tab}{x.Mount.PadRight(_padLen)}{__tab}{__tab}{__tab}{x.Amount}"));
            string total = $"{__tab}{__total.PadRight(_padLen)}{__tab}{__tab}{__tab}{employee.SalarySum}";
            return $"{__employee}{__colon}{__space}{fullname}"
                + $"{__rn}{byMonths}"
                + $"{__rn}{total}";
        }

        private static int GetMaxMountLen(IEnumerable<Employee> employees) =>
            Math.Max(__total.Length, employees
                .SelectMany(x => x.Salaries)
                .Max(x => x.Mount.Length));
    }
}
