using FlexibleCalculator.Calculator;
using FlexibleCalculator.Operations;
using NUnit.Framework;

namespace FlexibleCalculator.Tests
{
    public class RpnCalculatorTests
    {
        [Test]
        [TestCase("2+3-4*3", ExpectedResult = -7)]
        [TestCase("(2+3-4)*3", ExpectedResult = 3)]
        public double Calculate_Expression_ShouldReturnCalculatedExrepssion(string input)
        {
            var rpnCalculator = new RpnCalculator(new IOperation[] { new PlusOperation(), new MinusOperation(), new MultiplicationOperation() });

            var result = rpnCalculator.Calculate(input);

            return result;
        }
    }
}
