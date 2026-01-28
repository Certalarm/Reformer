using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System;
using System.Collections.Generic;

namespace RfrmLib.Tests.Fakes
{
    public class FakeWriter : IXmlDataWriter
    {
        public string Write(IEnumerable<Employee> employees, string xmlFullFilename)
        {
            throw new NotImplementedException();
        }

        public string Write(Pay pay, string xmlFullFilename)
        {
            throw new NotImplementedException();
        }
    }
}
