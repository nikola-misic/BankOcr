/*
 * account with "invalid" digits throws error
 *
 * 123456789 => 123456789
 * 987654321 => 987654321
 */

namespace BankOcrTests
{
    using BankOcr.Logic;
    using Xunit;

    public class OcrConverterTests
    {
        [Fact]
        public void CreateInstance()
        {
            new OcrConverter();
        }

        [Fact]
        public void Convert_ConvertsFromAsciiToString()
        {
            var input = new AsciiAccount(
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|");

            var actual = new OcrConverter().Convert(input);
            
            Assert.Equal("123456789", actual);
        }
        
        [Fact]
        public void Convert_ConvertsFromAsciiToStringDifferentOrder()
        {
            var input = new AsciiAccount(
                "    _  _     _  _  _  _  _ ",
                "  | _||_||_||_ |_   ||_| _|",
                "  ||_  _|  | _||_|  ||_| _|");

            var actual = new OcrConverter().Convert(input);
            
            Assert.Equal("129456783", actual);
        }
    }
}
