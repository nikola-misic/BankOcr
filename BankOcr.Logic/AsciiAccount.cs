namespace BankOcr.Logic
{
    using System;

    public class AsciiAccount
    {
        private readonly string lineOne;
        private readonly string lineTwo;
        private readonly string lineThree;
        
        public AsciiAccount(string lineOne, string lineTwo, string lineThree)
        {
            if (lineOne.Length != 27)
            {
                throw new ArgumentException(nameof(lineOne));
            }
            
            if (lineTwo.Length != 27)
            {
                throw new ArgumentException(nameof(lineTwo));
            }
            
            if (lineThree.Length != 27)
            {
                throw new ArgumentException(nameof(lineThree));
            }

            this.lineOne = lineOne;
            this.lineTwo = lineTwo;
            this.lineThree = lineThree;
        }

        public AsciiDigit DigitAt(int position)
        {
            int offset = position * 3;
            return new AsciiDigit(new char[3,3]
            {
                {lineOne[offset], lineOne[1+offset], lineOne[2+offset]},
                {lineTwo[offset], lineTwo[1+offset], lineTwo[2+offset]},
                {lineThree[offset], lineThree[1+offset], lineThree[2+offset]}
            });
        }
    }
}
