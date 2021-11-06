using FlexibleCalculator.Exceptions;
using FlexibleCalculator.Helpers;
using FlexibleCalculator.Operations;
using System.Collections.Generic;
using System.Linq;

namespace FlexibleCalculator.Calculator
{
    internal class ReversePolishNotationAlgo : IReversePolishNotationAlgo
    {
        private readonly Dictionary<string, IOperation> _operations;

        public ReversePolishNotationAlgo(IOperation[] operations)
        {
            _operations = operations
                .ToDictionary(x => x.GetOperation(), x => x);
        }

        public Token[] OrderTokens(IEnumerable<string> tokens)
        {
            var outputQueue = new Queue<Token>();
            var operatorStack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (char.IsDigit(token[0]))
                {
                    var number = DoubleParser.ParseAndIgnoreCalture(token);

                    outputQueue.Enqueue(new Token
                    {
                        TokenType = TokenType.Number,
                        Number = number
                    });
                    continue;
                }

                if (_operations.ContainsKey(token))
                {
                    var currentOperation = _operations[token];

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

                if (token == "(")
                {
                    operatorStack.Push(token);
                    continue;
                }

                if (token == ")")
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

                throw new UnexpectedCharacterException("Unexpected character");
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
