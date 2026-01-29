using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase.SaveEmployees
{
    public class SaveEmployeesInteractor
    {
        private IXmlDataWriter _writer;

        #region .ctors
        public SaveEmployeesInteractor(IXmlDataWriter writer)
        {
            _writer = writer;    
        }
        #endregion

        public string Execute(IEnumerable<Employee> employees, string outputDataFilename)
        {
            if (string.IsNullOrWhiteSpace(outputDataFilename))
                return __errorFilenames;

            if (employees is null)
                return __errorNullData;

            return _writer.Write(employees, outputDataFilename);
        }
    }
}
