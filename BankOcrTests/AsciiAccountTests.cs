namespace BankOcrTests
{
    using System;
    using Xunit;

    /*
     * - Create instance
     *  - receives 3 strings
     *  - validates correct lengths
     * - DigitAt(0)
     * - DigitAt(5)
     * - DigitAt(9)
     */

    public class AsciiAccountTests
    {
        [Fact]
        public void Constructor_LineOneMustBeOfCorrectLength()
        {
            string correctInput = "***************************";
            Assert.Throws<ArgumentException>(() => new AsciiAccount(string.Empty, correctInput, correctInput));
        }

        [Fact]
        public void Constructor_LineTwoMustBeOfCorrectLength()
        {
            string correctInput = "***************************";
            Assert.Throws<ArgumentException>(() => new AsciiAccount(correctInput, string.Empty, correctInput));
        }

        [Fact]
        public void Constructor_LineThreeMustBeOfCorrectLength()
        {
            string correctInput = "***************************";
            Assert.Throws<ArgumentException>(() => new AsciiAccount(correctInput, correctInput, string.Empty));
        }

        [Fact]
        public void DigitAt_PositionZero_ReturnsCorrectDigit()
        {
            var lineOne =   "   ************************";
            var lineTwo =   "  |************************";
            var lineThree = "  |************************";

            var expected = new AsciiDigit(new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', '|' },
                { ' ', ' ', '|' }
            });

            var actual = new AsciiAccount(lineOne, lineTwo, lineThree).DigitAt(0);
                
            Assert.Equal(expected, actual);
        }
    }


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
            return new AsciiDigit(new char[3,3]
            {
                {lineOne[0], lineOne[1], lineOne[2]},
                {lineTwo[0], lineTwo[1], lineTwo[2]},
                {lineThree[0], lineThree[1], lineThree[2]}
            });
        }
    }
}
