using RfrmLib.Data.Implementation.XmlDataReader;
using RfrmLib.Data.Implementation.XmlDataWriter;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddSalarySum;
using RfrmLib.Domain.UseCase.AddTotalAmount;
using RfrmLib.Domain.UseCase.GetEmployeesAmounts;
using RfrmLib.Domain.UseCase.SaveEmployees;
using RfrmLib.Domain.UseCase.SavePay;
using System.Collections.Generic;
using System.IO;

namespace RfrmLib.Controllers
{
    internal static class ControllerHelper
    {
        internal static IEnumerable<string> HandleMainFlow(string inputDataFilename, string stylesheetFilename, string outputDataFilename)
        {
            var reader = new XmlDataReader();
            AddSalarySumInteractor assi = new AddSalarySumInteractor(reader);
            (IEnumerable<Employee> employees, string error) = assi.Execute(inputDataFilename, stylesheetFilename);
            if (error.Length > 0)
                return [error];

            var writer = new XmlDataWriter();
            SaveEmployeesInteractor sei = new SaveEmployeesInteractor(writer);
            error = sei.Execute(employees, outputDataFilename);
            if (error.Length > 0)
                return [error];

            var atai = new AddTotalAmountInteractor(reader);
            (Pay pay, error) = atai.Execute(inputDataFilename);
            if (error.Length > 0)
                return [error];

            SavePayInteractor spi = new SavePayInteractor(writer);
            error = spi.Execute(pay, GetNewInputDataFilename(inputDataFilename, outputDataFilename));
            if (error.Length > 0)
                return [error];

            GetEmployeesAmountsInteractor geai = new GetEmployeesAmountsInteractor();
            return geai.Execute(employees);
        }

        internal static string GetNewInputDataFilename(string inputDataFilename, string outputDataFilename) =>
            Path.Combine(GetFolder(outputDataFilename), GetFilenameWithExt(inputDataFilename));
        private static string GetFolder(string fullFilename) => Path.GetDirectoryName(fullFilename);
        private static string GetFilenameWithExt(string fullFilename) => Path.GetFileName(fullFilename);
    }
}
