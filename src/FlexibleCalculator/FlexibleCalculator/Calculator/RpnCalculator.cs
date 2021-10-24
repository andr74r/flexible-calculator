using FlexibleCalculator.Operations;
using System.Collections.Generic;
using System.Linq;

namespace FlexibleCalculator.Calculator
{
    public class RpnCalculator : ICalculator
    {
        private readonly ReversePolishNotationAlgo _reversePolishNotationAlgo;
        private readonly IOperation[] _operations;

        public RpnCalculator(IOperation[] operations)
        {
            _reversePolishNotationAlgo = new ReversePolishNotationAlgo(operations);
            _operations = operations;
        }

        public double Calculate(string input)
        {
            var tokens = _reversePolishNotationAlgo.GetTokens(input);

            var stack = new Stack<string>(input.Length);

            foreach (var token in tokens)
            {
                if (char.IsDigit(token[0]))
                {
                    stack.Push(token);

                    continue;
                }

                var operation = _operations.First(_ => _.GetOperation() == token);

                var y = double.Parse(stack.Pop());
                var x = double.Parse(stack.Pop());

                stack.Push(operation.Execute(x, y).ToString());
            }

            return double.Parse(stack.Peek());
        }
    }
}
