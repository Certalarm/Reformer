using System.Collections.Generic;

namespace RfrmLib.Domain.Entity
{
    public class Pay
    {
        public string TotalAmount { get; set; }
        public List<Item> Items { get; set; }

        #region .ctors
        public Pay(string totalAmount, List<Item> items = default)
        {
            TotalAmount = totalAmount;
            Items = items ?? [];
        }
        #endregion
    }
}
