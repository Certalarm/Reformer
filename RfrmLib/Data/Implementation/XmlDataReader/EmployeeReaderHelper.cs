using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Data.Implementation.XmlDataReader
{
    internal static class EmployeeReaderHelper
    {
        internal static (IEnumerable<Employee>, string) ReadWithTransform(string xmlInputFileFullname, string xmlStyleSheetFullname)
        {
            var transform = new XslCompiledTransform();
            try
            {
                transform.Load(xmlStyleSheetFullname);
                using MemoryStream memoryStream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(memoryStream);
                using XmlReader reader = XmlReader.Create(xmlInputFileFullname);
                transform.Transform(reader, writer);
                return (ReadEmployees(memoryStream), string.Empty);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        private static IEnumerable<Employee> ReadEmployees(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;       
            using XmlReader reader = XmlReader.Create(memoryStream);
            return ReadTransformed(reader);
        }

        private static IEnumerable<Employee> ReadTransformed(XmlReader reader)
        {
            IList<Employee> result = [];
            while (reader.Read())
            {
                if (NeedSkipNode(reader))
                    continue;
                (string tmpName, string tmpSurname) = ReadEmployeeAttrs(reader);
                if (reader.IsEmptyElement)
                    continue;
                result.Add(new Employee(tmpName, tmpSurname, ReadSalaries(reader)));
            }
            return result;
        }

        private static bool NeedSkipNode(XmlReader xmlReader) =>
            xmlReader.NodeType != XmlNodeType.Element || xmlReader.Name != __employee || !xmlReader.HasAttributes;

        private static (string, string) ReadEmployeeAttrs(XmlReader reader)
        {
            var name = string.Empty;
            var surname = string.Empty;
            reader.MoveToFirstAttribute();
            do
            {
                if (reader.Name == __name)
                    name = reader.Value;
                if (reader.Name == __surname)
                    surname = reader.Value;
            } while (reader.MoveToNextAttribute());
            return (name, surname);
        }

        private static List<Salary> ReadSalaries(XmlReader reader)
        {
            var result = new List<Salary>();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.Name == __salary && reader.HasAttributes)
                {
                    (string amount, string mount) = ReadSalaryAttrs(reader);
                    result.Add(new Salary(amount, mount));
                }
                reader.Read();
            }
            return result;
        }

        private static (string, string) ReadSalaryAttrs(XmlReader reader)
        {
            var amount = string.Empty;
            var mount = string.Empty;
            reader.MoveToFirstAttribute();
            do
            {
                if (reader.Name == __amount)
                    amount = reader.Value;
                if (reader.Name == __mount)
                    mount = reader.Value;
            } while (reader.MoveToNextAttribute());
            return (amount, mount);
        }
    }
}
