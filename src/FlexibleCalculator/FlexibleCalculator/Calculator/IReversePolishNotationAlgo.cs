using System.Collections.Generic;

namespace FlexibleCalculator.Calculator
{
    public interface IReversePolishNotationAlgo
    {
        Token[] OrderTokens(IEnumerable<string> tokens);
    }
}
