using System.Globalization;

namespace RfrmLib.Utility
{
    public static class Txt
    {
        public const string __errorBadParams = "Bad params by Write Xml Data";
        public const string __errorFilenames = "Input filenames are incorrect";

        public const string __name = "name";
        public const string __surname = "surname";
        public const string __amount = "amount";
        public const string __mount = "mount";
        public const string __employees = "Employees";
        public const string __employee = "Employee";
        public const string __salary = "salary";
        public const string __pay = "Pay";
        public const string __item = "item";

        public const string __dot = ".";
        public const string __comma = ",";
        public static readonly string __systemDecimalSeparator =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    }
}
