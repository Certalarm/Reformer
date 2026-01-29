using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using static RfrmLib.Domain.UseCase.InteractorHelper;

namespace RfrmLib.Domain.UseCase.AddTotalAmount
{
    public class AddTotalAmountInteractor
    {
        private IXmlDataReader _reader;

        #region .ctor
        public AddTotalAmountInteractor(IXmlDataReader reader)
        {
            _reader = reader;    
        }
        #endregion

        public (Pay, string) Execute(string inputDataFilename)
        {
            (Pay pay, string error) = _reader.Read(inputDataFilename);
            if (error.Length > 0)
                return (null, error);
            pay.TotalAmount = CalcTotalAmount(pay.Items);
            return (pay, string.Empty);
        }

        private string CalcTotalAmount(IEnumerable<Item> items) =>
            items
                .Sum(x => ToDouble(x.Amount))
                .ToString();
    }
}
