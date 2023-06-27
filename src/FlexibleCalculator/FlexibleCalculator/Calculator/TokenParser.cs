using FlexibleCalculator.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FlexibleCalculator.Tests")]
namespace FlexibleCalculator.Calculator
{
    internal class TokenParser : ITokenParser
    {
        public IEnumerable<string> Parse(string input)
        {
            var currentToken = string.Empty;

            foreach (var symbol in input.Where(x => !char.IsWhiteSpace(x)))
            {
                if (char.IsLetterOrDigit(symbol) || symbol.IsDecimalSeparator())
                {
                    currentToken += symbol;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        yield return currentToken;
                        currentToken = string.Empty;
                    }

                    yield return symbol.ToString();
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                yield return currentToken;
            }
        }
    }
}
