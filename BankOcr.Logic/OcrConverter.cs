namespace BankOcr.Logic
{
    using System.Collections.Generic;
    using System.Text;

    public class OcrConverter
    {
        private readonly Dictionary<AsciiDigit, string> digitMap = new Dictionary<AsciiDigit, string>
        {
            { AsciiDigit.One, "1"},
            { AsciiDigit.Two, "2"},
            { AsciiDigit.Three, "3"},
            { AsciiDigit.Four, "4"},
            { AsciiDigit.Five, "5"},
            { AsciiDigit.Six, "6"},
            { AsciiDigit.Seven, "7"},
            { AsciiDigit.Eight, "8"},
            { AsciiDigit.Nine, "9"}
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
