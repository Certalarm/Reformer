using RfrmLib.Domain.Entity;
using System;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Controllers
{
    internal static class Mapper
    {
        internal static Item ToDomain(string stringItem)
        {
            var emptyItem = new Item(string.Empty, string.Empty, string.Empty, string.Empty);
            var parts = stringItem.Split([__splitter], StringSplitOptions.None);
            if (parts.Length < 4)
                return emptyItem;
            if (string.IsNullOrWhiteSpace(parts[0]) && string.IsNullOrWhiteSpace(parts[1]))
                return emptyItem;

            return new Item(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
