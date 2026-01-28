using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using static RfrmLib.Data.Implementation.XmlDataWriter.XmlDataWriterHelper;

namespace RfrmLib.Data.Implementation.XmlDataWriter
{
    internal class XmlDataWriter : IXmlDataWriter
    {
        const string __errorBadParams = "Bad params by Write Xml Data";

        public string Write(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            return (IsBadEmployees(employees) || IsBadFilename(xmlFullFilename))
                ? __errorBadParams
                : TryWriteEmployees(employees, xmlFullFilename);
        }

        public string Write(Pay pay, string xmlFullFilename)
        {
            return (IsBadFilename(xmlFullFilename))
                ? __errorBadParams
                : TryWritePay(pay, xmlFullFilename);
        }

        private static bool IsBadEmployees(IEnumerable<Employee> employees) =>
            employees is null || !employees.Any();

        private static bool IsBadFilename(string filename) =>
            string.IsNullOrWhiteSpace(filename);
    }
}
