using FlexibleCalculator.Calculator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FlexibleCalculator.Tests
{
    public class TokenParserTests
    {
        [Test]
        [TestCase("(2+3)*4", new[] { "(", "2", "+", "3", ")", "*", "4" })]
        [TestCase("sin(2+3) - 22.341 * (22 + 3) - (3+13)! + 3^6.3", 
            new[] { "sin", "(", "2", "+", "3", ")", "-", "22.341", "*", "(", "22", "+", "3", ")", "-", "(", "3", "+", "13", ")", "!", "+", "3", "^", "6.3"  })]
        public void Parse_InputString_ShouldReturnTokens(string input, IEnumerable<string> expectedTokens)
        {
            var tokenParser = new TokenParser();

            var actualTokens = tokenParser.Parse(input);

            Assert.That(actualTokens, Is.EquivalentTo(expectedTokens));
        }
    }
}
