using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;

namespace RfrmLib.Tests.Fakes
{
    public class FakeReader : IXmlDataReader
    {
        public (IEnumerable<Employee>, string) Read(string xmlInputFileFullname, string xmlStyleSheetFullname)
        {
            throw new NotImplementedException();
        }
    }
}
