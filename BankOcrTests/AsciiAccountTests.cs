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
    }


    public class AsciiAccount
    {
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
        }
    }
}
