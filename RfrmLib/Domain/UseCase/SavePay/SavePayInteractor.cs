using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase.SavePay
{
    public class SavePayInteractor
    {
        private IXmlDataWriter _writer;

        #region .ctors
        public SavePayInteractor(IXmlDataWriter writer)
        {
            _writer = writer;
        }
        #endregion

        public string Execute(Pay pay, string outputDataFilename)
        {
            if (string.IsNullOrWhiteSpace(outputDataFilename))
                return __errorFilenames;

            return _writer.Write(pay, outputDataFilename);  
        }
    }
}
