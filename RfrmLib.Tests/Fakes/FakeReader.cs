using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using RfrmLib.Tests.Data;
using System.Collections.Generic;

namespace RfrmLib.Tests.Fakes
{
    public class FakeReader : IXmlDataReader
    {
        public (IEnumerable<Employee>, string) Read(string xmlInputFileFullname, string xmlStyleSheetFullname)
        {
            return (Employees.Get(), string.Empty);
        }
    }
}
