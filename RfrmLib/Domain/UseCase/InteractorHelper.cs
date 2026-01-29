using static RfrmLib.Utility.Txt;

namespace RfrmLib.Domain.UseCase
{
    public static class InteractorHelper
    {
        public static double ToDouble(string value) =>
            double.Parse(NormalizeDecimalSeparator(value));

        private static string NormalizeDecimalSeparator(string value) =>
            value
                .Replace(__comma, __dot)
                .Replace(__dot, __systemDecimalSeparator);
    }
}
