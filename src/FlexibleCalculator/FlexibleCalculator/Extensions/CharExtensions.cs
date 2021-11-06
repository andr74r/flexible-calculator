namespace FlexibleCalculator.Extensions
{
    public static class CharExtensions
    {
        public static bool IsDecimalSeparator(this char c)
        {
            if (c == ',' || c == '.')
            {
                return true;
            }

            return false;
        }
    }
}
