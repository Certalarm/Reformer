using RfrmLib.Domain.Entity;
using System.Collections.Generic;

namespace RfrmLib.Tests.Data
{
    public static class Pays
    {
        public static Pay Get() =>
            new(string.Empty, GetItems());

        private static List<Item> GetItems() =>
            [
            new Item("Lena", "Ivanova", "1001.1", "march"),
            new Item("Lena", "Ivanova", "2001", "january"),
            new Item("Lena", "Ivanova", "3001,10", "february"),
            new Item("Masha", "Ivanova", "1000", "march"),
            new Item("Masha", "Ivanova", "2000.0", "january"),
            new Item("Masha", "Ivanova", "3000", "february"),
            ];
    }
}
