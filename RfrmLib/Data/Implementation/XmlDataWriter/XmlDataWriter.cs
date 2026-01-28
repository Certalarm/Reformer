using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RfrmLib.Data.Implementation.XmlDataWriter
{
    internal class XmlDataWriter : IXmlDataWriter
    {
        const string __employees = "Employees";
        const string __employee = "Employee";

        public string Write(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            XmlWriterSettings xws = new XmlWriterSettings() { Indent = true };
            using XmlWriter writer = XmlWriter.Create(xmlFullFilename, xws);
            writer.WriteStartElement(__employees);

            foreach (var employee in employees)
            {
                writer.WriteStartElement(__employee);
                writer.WriteAttributeString(nameof(employee.Name).ToLower(), employee.Name);
                writer.WriteAttributeString(nameof(employee.Surname).ToLower(), employee.Surname);
                writer.WriteAttributeString(nameof(employee.SalarySum).ToLower(), AsString(employee.SalarySum));

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        public string Write(Pay pay, string xmlFullFilename)
        {
            throw new NotImplementedException();
        }

        private static string AsString(double value) =>
            value.ToString().Replace(",", ".");
    }
}
