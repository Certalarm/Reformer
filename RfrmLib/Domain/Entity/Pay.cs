using System.Collections.Generic;

namespace RfrmLib.Domain.Entity
{
    internal class Pay
    {
        public double TotalAmount { get; }
        public List<Item> Items { get; set; }

        #region .ctors
        public Pay(double totalAmount, List<Item> items = default)
        {
            TotalAmount = totalAmount;
            Items = items ?? [];
        }
        #endregion
    }
}
