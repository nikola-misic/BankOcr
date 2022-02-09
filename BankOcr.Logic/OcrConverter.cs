namespace BankOcr.Logic
{
    using System.Collections.Generic;
    using System.Text;

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
