/*
 * account with "invalid" digits throws error
 *
 * 123456789 => 123456789
 * 987654321 => 987654321
 */

namespace BankOcrTests
{
    using System.Collections.Generic;
    using System.Text;
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

    public class OcrConverter
    {
        private readonly Dictionary<AsciiDigit, string> digitMap = new Dictionary<AsciiDigit, string>
        {
            { new AsciiDigit(new char[,] {
                {' ', ' ' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            }), "1"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {' ', '_', '|'},
                {'|', '_', ' '}
            }), "2"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {' ', '_', '|'},
                {' ', '_', '|'}
            }), "3"},
            
            { new AsciiDigit(new char[,] {
                {' ', ' ' ,' '},
                {'|', '_', '|'},
                {' ', ' ', '|'}
            }), "4"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {'|', '_', ' '},
                {' ', '_', '|'}
            }), "5"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {'|', '_', ' '},
                {'|', '_', '|'}
            }), "6"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            }), "7"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {'|', '_', '|'},
                {'|', '_', '|'}
            }), "8"},
            
            { new AsciiDigit(new char[,] {
                {' ', '_' ,' '},
                {'|', '_', '|'},
                {' ', '_', '|'}
            }), "9"},
        };


        public string Convert(AsciiAccount input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                sb.Append(digitMap[input.DigitAt(i)]);
            }

            return sb.ToString();
        }
    }
}
