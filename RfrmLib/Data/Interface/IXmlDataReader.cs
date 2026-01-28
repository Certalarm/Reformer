using RfrmLib.Domain.Entity;
using System.Collections.Generic;

namespace RfrmLib.Data.Interface
{
    public interface IXmlDataReader
    {
        public (IEnumerable<Employee>, string) Read(string xmlInputFileFullname, string xmlStyleSheetFullname);
    }
}
