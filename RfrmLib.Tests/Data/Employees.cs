using RfrmLib.Domain.Entity;

namespace RfrmLib.Tests.Data
{
    public static class Employees
    {
        public static Employee[] Get() =>
            [
            new("Lena", "Ivanova", 
                [
                new("1001.1", "march"),
                new("2001", "january"),
                new("3001,10", "february"),
                ]),
            new("Masha", "Ivanova", 
                [
                new("1000", "march"),
                new("2000.0", "january"),
                new("3000", "february")
                ])
            ];
    }
}
