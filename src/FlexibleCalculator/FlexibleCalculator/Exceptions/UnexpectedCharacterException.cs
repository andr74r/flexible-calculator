using System;

namespace FlexibleCalculator.Exceptions
{
    public class UnexpectedCharacterException : Exception
    {
        public UnexpectedCharacterException(string msg) : base(msg)
        {

        }
    }
}
