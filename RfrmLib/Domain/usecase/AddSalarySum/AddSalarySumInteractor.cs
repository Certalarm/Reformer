using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase.AddSalarySum
{
    public class AddSalarySumInteractor
    {
        private IXmlDataReader _reader;
        private IXmlDataWriter _writer;

        #region .ctors
        public AddSalarySumInteractor(IXmlDataReader reader, IXmlDataWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }
        #endregion

        public string Execute(string inputDataFilename, string stylesheetFilename, string outputDataFilename)
        {
            (IEnumerable<Employee> employees, string error) = _reader.Read(inputDataFilename, stylesheetFilename);
            if (error.Length > 0)
                return error;
            foreach(var employee in employees)
                AddSalarySum(employee);
            return _writer.Write(employees, outputDataFilename);
        }

        private void AddSalarySum(Employee employee)
        {
            employee.SalarySum = CalcSalariesSum(employee.Salaries).ToString();
        }

        private static double CalcSalariesSum(IEnumerable<Salary> salaries) =>
            salaries.Any()
                ? salaries
                    .Sum(x => ToDouble(x.Amount))
                : 0;

        private static double ToDouble(string value) =>
            double.Parse(NormalizeDecimalSeparator(value));

        private static string NormalizeDecimalSeparator(string value) =>
            value
                .Replace(__comma, __dot)
                .Replace(__dot, __systemDecimalSeparator);
    }
}
