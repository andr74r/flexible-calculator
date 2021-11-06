using System.Globalization;

namespace FlexibleCalculator.Helpers
{
    public static class DoubleParser
    {
        public static double ParseAndIgnoreCalture(string input)
        {
            return double.Parse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
        }
    }
}
