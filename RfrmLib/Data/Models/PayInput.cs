using System.Collections.Generic;

namespace RfrmLib.Data.Models
{
    internal class PayInput
    {
        public string TotalAmount { get; }
        public List<ItemInput> Items { get; set; }

        #region .ctors
        public PayInput(string totalAmount, List<ItemInput> items = default)
        {
            TotalAmount = totalAmount;
            Items = items ?? [];
        }
        #endregion
    }
}
