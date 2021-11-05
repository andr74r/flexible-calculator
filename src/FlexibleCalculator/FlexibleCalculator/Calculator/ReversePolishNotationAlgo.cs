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

        public Token[] GetTokens(string input)
        {
            var outputQueue = new Queue<Token>(input.Length);
            var operatorStack = new Stack<string>(input.Length);

            foreach (var symbol in input.Select(x => x.ToString()))
            {
                if (char.IsDigit(symbol[0]))
                {
                    var number = double.Parse(symbol);

                    outputQueue.Enqueue(new Token
                    {
                        TokenType = TokenType.Number,
                        Number = number
                    });
                    continue;
                }

                if (_operations.ContainsKey(symbol))
                {
                    var currentOperation = _operations[symbol];

                    while (operatorStack.Count > 0 
                        && _operations.ContainsKey(operatorStack.Peek()) 
                        && _operations[operatorStack.Peek()].GetPriority() >= currentOperation.GetPriority())
                    {
                        outputQueue.Enqueue(new Token
                        {
                            TokenType = TokenType.Operation,
                            Operation = _operations[operatorStack.Pop()]
                        });
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
                        outputQueue.Enqueue(new Token
                        {
                            TokenType = TokenType.Operation,
                            Operation = _operations[operatorStack.Pop()]
                        });
                    }

                    operatorStack.Pop();
                    continue;
                }

                throw new System.ArgumentException("Unexpected character");
            }

            while(operatorStack.Count != 0)
            {
                outputQueue.Enqueue(new Token
                {
                    TokenType = TokenType.Operation,
                    Operation = _operations[operatorStack.Pop()]
                });
            }

            return outputQueue.ToArray();
        }
    }
}
