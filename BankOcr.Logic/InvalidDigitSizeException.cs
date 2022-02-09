namespace BankOcr.Logic
{
    using System;

    public class InvalidDigitSizeException : Exception
    {
        public InvalidDigitSizeException(int rows, int columns)
            : base($"Invalid matrix size {rows}x{columns}")
        {
        }
    }
}