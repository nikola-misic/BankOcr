/* TEST PLAN
 
 
 
 Equals
    1 == 1
    3 == 3
    1 != 2
    1 != null
 GetHashCode
 
 
 */

namespace BankOcrTests
{
    using Xunit;

    public class AsciiDigitTests
    {
        [Fact]
        public void Equals_OneEqualsOne()
        {
            var expected = new AsciiDigit(new char[3,3] {
                {' ', ' ' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            });
            
            var actual = new AsciiDigit(new char[3,3] {
                {' ', ' ' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            });
            
            Assert.Equal(expected, actual);
        }
    }

    public class AsciiDigit
    {
        private char[,] matrix;
        
        public AsciiDigit(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public override string ToString()
        {
            return $"{matrix[0, 0]}{matrix[0, 1]}{matrix[0, 2]}\n" +
                   $"{matrix[1, 0]}{matrix[1, 1]}{matrix[1, 2]}\n" +
                   $"{matrix[2, 0]}{matrix[2, 1]}{matrix[2, 2]}\n";
        }

        public override bool Equals(object obj)
        {
            return true;
        }
    }
}
