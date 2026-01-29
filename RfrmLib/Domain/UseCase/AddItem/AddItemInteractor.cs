using RfrmLib.Data.Interface;
using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using static RfrmLib.Domain.UseCase.InteractorHelper;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase.AddItem
{
    public class AddItemInteractor
    {
        private readonly IXmlDataReader _reader;

        #region .ctors
        public AddItemInteractor(IXmlDataReader reader)
        {
            _reader = reader;    
        }
        #endregion

        public (Pay, string) Execute(string inputDataFilename, Item item)
        {
            (Pay pay, string error) = _reader.Read(inputDataFilename);
            if (error.Length > 0)
                return (null, error);
            error = AddItem(pay, item);
            if (error.Length > 0)
                return (null, error);
            pay.TotalAmount = CalcTotalAmount(pay.Items);
            return (pay, string.Empty);
        }

        private string AddItem(Pay pay, Item item)
        {
            if (item is null)
                return __errorNullData;
            pay.Items.Add(item);
            return string.Empty;
        }

        private string CalcTotalAmount(IEnumerable<Item> items) =>
            items
                .Sum(x => ToDouble(x.Amount))
                .ToString();
    }
}
