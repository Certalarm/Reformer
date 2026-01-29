using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Xml;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Data.Implementation.XmlDataWriter
{
    internal static class XmlDataWriterHelper
    {
        internal static string TryWriteEmployees(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            try
            {
                using XmlWriter writer = XmlWriter.Create(xmlFullFilename, CreateXmlSettings());
                WriteEmployees(writer, employees);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        internal static string TryWritePay(Pay pay, string xmlFullFilename)
        {
            try
            {
                using XmlWriter writer = XmlWriter.Create(xmlFullFilename, CreateXmlSettings());
                WritePay(writer, pay);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        private static void WriteEmployees(XmlWriter writer, IEnumerable<Employee> employees)
        {
            writer.WriteStartElement(__employees);
            foreach (var employee in employees)
                WriteEmployee(writer, employee);
            writer.WriteEndElement();
        }

        private static void WriteEmployee(XmlWriter writer, Employee employee)
        {
            writer.WriteStartElement(__employee);
            writer.WriteAttributeString(nameof(employee.Name).ToLower(), employee.Name);
            writer.WriteAttributeString(nameof(employee.Surname).ToLower(), employee.Surname);
            writer.WriteAttributeString(nameof(employee.SalarySum).ToLower(), employee.SalarySum);
            foreach (var salary in employee.Salaries)
                WriteSalary(writer, salary);
            writer.WriteEndElement();
        }

        private static void WriteSalary(XmlWriter writer, Salary salary)
        {
            writer.WriteStartElement(__salary);
            writer.WriteAttributeString(nameof(salary.Amount).ToLower(), salary.Amount);
            writer.WriteAttributeString(nameof(salary.Mount).ToLower(), salary.Mount);
            writer.WriteEndElement();
        }

        private static void WritePay(XmlWriter writer, Pay pay)
        {
            writer.WriteStartElement(__pay);
            writer.WriteAttributeString(nameof(pay.TotalAmount).ToLower(), pay.TotalAmount);
            foreach (var item in pay.Items)
                WriteItem(writer, item);
            writer.WriteEndElement();
        }

        private static void WriteItem(XmlWriter writer, Item item)
        {
            writer.WriteStartElement(__item);
            writer.WriteAttributeString(nameof(item.Name).ToLower(), item.Name);
            writer.WriteAttributeString(nameof(item.Surname).ToLower(), item.Surname);
            writer.WriteAttributeString(nameof(item.Amount).ToLower(), item.Amount);
            writer.WriteAttributeString(nameof(item.Mount).ToLower(), item.Mount);
            writer.WriteEndElement();
        }

        private static XmlWriterSettings CreateXmlSettings() =>
            new()
            {
                Indent = true
            };
    }
}
