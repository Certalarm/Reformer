using RfrmLib.Data.Interface;
using RfrmLib.Data.Mapper;
using RfrmLib.Data.Models;
using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Xsl;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Data.Implementation.XmlDataReader
{
    internal class XmlDataReader : IXmlDataReader
    {
        #region .ctors
        public XmlDataReader()
        {
        }
        #endregion

        public (IEnumerable<Employee>, string) Read(string xmlInputFileFullname, string xmlStyleSheetFullname)
        {
            if (HasBadParam(xmlInputFileFullname, xmlStyleSheetFullname))
                return (Enumerable.Empty<Employee>(), __errorFilenames);
            
            (XmlReader reader, string error) = TransformToXmlReader(xmlInputFileFullname, xmlStyleSheetFullname);
            if (error.Length > 0)
                return (Enumerable.Empty<Employee>(), error);
            return (ReadTransformed(reader), string.Empty);
        }

        private IEnumerable<Employee> ReadTransformed(XmlReader reader)
        {
            XmlDocument doc = new();
            IList<Employee> result = [];
            while (reader.Read())
            {
                if (NeedSkipNode(reader)) continue;
                var node = SelectEmployeeNode(doc, reader);
                var employee = ParseEmployee(node);
                result.Add(employee.ToDomain());
            }
            return result;
        }

        private (XmlReader, string) TransformToXmlReader(string xmlInputFileFullname, string xmlStyleSheetFullname)
        {
            var transform = new XslCompiledTransform();
            try
            {
                transform.Load(xmlStyleSheetFullname);
                using MemoryStream memoryStream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(memoryStream);
                using XmlReader reader = XmlReader.Create(xmlInputFileFullname);
                transform.Transform(reader, writer);
                memoryStream.Position = 0;
                return (XmlReader.Create(memoryStream), string.Empty);
            }
            catch(Exception ex)
            {
                return (null, ex.Message);
            }
        }

        private bool NeedSkipNode(XmlReader xmlReader) =>
            xmlReader.NodeType != XmlNodeType.Element || xmlReader.Name != __employee;

        private XmlNode SelectEmployeeNode(XmlDocument doc, XmlReader xmlReader)
        {
            doc.LoadXml(xmlReader.ReadOuterXml());
            return doc.SelectSingleNode(__employee)!;
        }

        private EmployeeInput ParseEmployee(XmlNode node)
        {
            var emptyEmployee = new EmployeeInput(string.Empty, string.Empty);
            if (node.Attributes!.Count < 1)
                return emptyEmployee;
            string name = node.Attributes[__name]!.Value;
            string surname = node.Attributes[__surname]!.Value;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(surname))
                return emptyEmployee;
            var salaries = ParseSalaries(node.ChildNodes);
            return new EmployeeInput(name, surname, salaries);
        }

        private IList<SalaryInput> ParseSalaries(XmlNodeList nodes)
        {
            IList<SalaryInput> result = [];
            foreach (XmlNode node in nodes)
                if (node.Name == __salary)
                {
                    string amount = node.Attributes[__amount]!.Value;
                    string mount = node.Attributes[__mount]!.Value;
                    result.Add(new SalaryInput(amount, mount)); 
                }
            return result;
        }

        private static bool HasBadParam(params string[] values) =>
            values
                .Any(IsBadParam);

        private static bool IsBadParam(string filename) =>
            string.IsNullOrWhiteSpace(filename) || !File.Exists(filename);
    }
}
