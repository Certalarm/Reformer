using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;

namespace RfrmLib.Tests.Fakes
{
    public class FakeWriter : IXmlDataWriter
    {
        public string Write(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            return "";
        }

        public string Write(Pay pay, string xmlFullFilename)
        {
            return "";
        }
    }
}
