using FlexibleCalculator.Operations;
using System.Collections.Generic;

namespace FlexibleCalculator.Calculator
{
    public class RpnCalculator : ICalculator
    {
        private readonly ReversePolishNotationAlgo _reversePolishNotationAlgo;
   
        public RpnCalculator(IOperation[] operations)
        {
            _reversePolishNotationAlgo = new ReversePolishNotationAlgo(operations);
        }

        public double Calculate(string input)
        {
            var tokens = _reversePolishNotationAlgo.GetTokens(input);

            var stack = new Stack<Token>(input.Length);

            foreach (var token in tokens)
            {
                if (token.TokenType == TokenType.Number)
                {
                    stack.Push(token);

                    continue;
                }

                var operation = token.Operation;

                var y = stack.Pop().Number.Value;
                var x = stack.Pop().Number.Value;

                stack.Push(new Token
                {
                    TokenType = TokenType.Number,
                    Number = operation.Execute(x, y)
                });
            }

            return stack.Peek().Number.Value;
        }
    }
}
