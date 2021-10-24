using FlexibleCalculator.Operations;
using System.Collections.Generic;
using System.Linq;

namespace FlexibleCalculator.Calculator
{
    internal class ReversePolishNotationAlgo
    {
        private readonly Dictionary<string, IOperation> _operations;

        public ReversePolishNotationAlgo(IOperation[] operations)
        {
            _operations = operations
                .ToDictionary(x => x.GetOperation(), x => x);
        }

        public string[] GetTokens(string input)
        {
            var outputQueue = new Queue<string>(input.Length);
            var operatorStack = new Stack<string>(input.Length);

            foreach (var symbol in input.Select(x => x.ToString()))
            {
                if (char.IsDigit(symbol[0]))
                {
                    outputQueue.Enqueue(symbol);
                    continue;
                }

                if (_operations.ContainsKey(symbol))
                {
                    var currentOperation = _operations[symbol];

                    while (operatorStack.Count > 0 
                        && _operations.ContainsKey(operatorStack.Peek()) 
                        && _operations[operatorStack.Peek()].GetPriority() >= currentOperation.GetPriority())
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    operatorStack.Push(currentOperation.GetOperation());

                    continue;
                }

                if (symbol == "(")
                {
                    operatorStack.Push(symbol);
                    continue;
                }

                if (symbol == ")")
                {
                    while(operatorStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    operatorStack.Pop();
                    continue;
                }

                throw new System.ArgumentException("Unexpected character");
            }

            while(operatorStack.Count != 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue.ToArray();
        }
    }
}
