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
        [TestCase("22.311+3.1", ExpectedResult = 25.411)]
        public double Calculate_Expression_ShouldReturnCalculatedExrepssion(string input)
        {
            var tokenParser = new TokenParser();
            var rpnAlgo = new ReversePolishNotationAlgo(new IOperation[] { new PlusOperation(), new MinusOperation(), new MultiplicationOperation() });
            var rpnCalculator = new RpnCalculator(rpnAlgo, tokenParser);

            var result = rpnCalculator.Calculate(input);

            return result;
        }
    }
}
