using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Xml;

namespace RfrmLib.Data.Implementation.XmlDataWriter
{
    internal class XmlDataWriter : IXmlDataWriter
    {
        const string __employees = "Employees";
        const string __employee = "Employee";
        const string __salary = "salary";

        public string Write(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            try
            {
                using XmlWriter writer = XmlWriter.Create(xmlFullFilename, CreateXmlSettings());
                WriteEmployees(writer, employees);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public string Write(Pay pay, string xmlFullFilename)
        {
            throw new NotImplementedException();
        }

        private void WriteEmployees(XmlWriter writer, IEnumerable<Employee> employees)
        {
            writer.WriteStartElement(__employees);
            foreach (var employee in employees)
                WriteEmployee(writer, employee);
            writer.WriteEndElement();
        }

        private void WriteEmployee(XmlWriter writer, Employee employee)
        {
            writer.WriteStartElement(__employee);
            writer.WriteAttributeString(nameof(employee.Name).ToLower(), employee.Name);
            writer.WriteAttributeString(nameof(employee.Surname).ToLower(), employee.Surname);
            writer.WriteAttributeString(nameof(employee.SalarySum).ToLower(), employee.SalarySum);
            foreach (var salary in employee.Salaries)
                WriteSalary(writer, salary);
            writer.WriteEndElement();
        }

        private void WriteSalary(XmlWriter writer, Salary salary)
        {
            writer.WriteStartElement(__salary);
            writer.WriteAttributeString(nameof(salary.Amount).ToLower(), salary.Amount);
            writer.WriteAttributeString(nameof(salary.Mount).ToLower(), salary.Mount);
            writer.WriteEndElement();
        }

        private static XmlWriterSettings CreateXmlSettings() =>
            new()
            {
                Indent = true
            };
    }
}
