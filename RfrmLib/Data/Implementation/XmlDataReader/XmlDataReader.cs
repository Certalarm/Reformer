using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using static RfrmLib.Data.Implementation.XmlDataReader.EmployeeReaderHelper;
using static RfrmLib.Data.Implementation.XmlDataReader.PayReaderHelper;
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

        public (Pay, string) Read(string xmlInputFileFullname)
        {
            if (IsBadParam(xmlInputFileFullname))
                return (null, __errorFilenames);

            return ReadPay(xmlInputFileFullname);
        }

        private static bool HasBadParam(params string[] values) =>
            values
                .Any(IsBadParam);

        private static bool IsBadParam(string filename) =>
            string.IsNullOrWhiteSpace(filename) || !File.Exists(filename);
    }
}
