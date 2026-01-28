using RfrmLib.Domain.Entity;
using System.Collections.Generic;

namespace RfrmLib.Data.Interface
{
    internal interface IXmlDataWriter
    {
        public string Write(IEnumerable<Employee> employees, string xmlFullFilename);
        public string Write(Pay pay, string xmlFullFilename);
    }
}
