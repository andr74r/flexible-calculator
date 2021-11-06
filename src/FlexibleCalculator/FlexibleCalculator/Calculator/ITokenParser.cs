using System.Collections.Generic;

namespace FlexibleCalculator.Calculator
{
    public interface ITokenParser
    {
        IEnumerable<string> Parse(string input);
    }
}
