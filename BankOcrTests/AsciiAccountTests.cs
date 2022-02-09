namespace BankOcrTests
{
    using System;
    using BankOcr.Logic;
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
        
        [Fact]
        public void DigitAt_PositionFive_ReturnsCorrectDigit()
        {
            var lineOne =   "*************** _ *********";
            var lineTwo =   "***************|_|*********";
            var lineThree = "***************|_|*********";

            var expected = new AsciiDigit(new char[,]
            {
                { ' ', '_', ' ' },
                { '|', '_', '|' },
                { '|', '_', '|' }
            });

            var actual = new AsciiAccount(lineOne, lineTwo, lineThree).DigitAt(5);
                
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DigitAt_PositionNine_ReturnsCorrectDigit()
        {
            var lineOne =   "************************ _ ";
            var lineTwo =   "************************  |";
            var lineThree = "************************  |";

            var expected = new AsciiDigit(new char[,]
            {
                { ' ', '_', ' ' },
                { ' ', ' ', '|' },
                { ' ', ' ', '|' }
            });

            var actual = new AsciiAccount(lineOne, lineTwo, lineThree).DigitAt(8);
                
            Assert.Equal(expected, actual);
        }
    }
}
