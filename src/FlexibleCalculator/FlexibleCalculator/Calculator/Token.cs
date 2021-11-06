using FlexibleCalculator.Operations;

namespace FlexibleCalculator.Calculator
{
    public class Token
    {
        public TokenType TokenType { get; set; }

        public IOperation Operation { get; set; }

        public double? Number { get; set; }
    }
}
