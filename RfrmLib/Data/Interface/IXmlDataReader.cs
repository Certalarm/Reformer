using RfrmLib.Domain.Entity;
using System.Collections.Generic;

namespace RfrmLib.Data.Interface
{
    internal interface IXmlDataReader
    {
        public (IEnumerable<Employee>, string) Read(string xmlInputFileFullname, string xmlStyleSheetFullname);
    }
}
