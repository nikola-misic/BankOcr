/* TEST PLAN
 
 Constructor
    matrix != null
    matrix == 3x3
 
 Equals
    1 == 1
    3 == 3
    1 != 2
    1 != null
 GetHashCode
 
 
 */

namespace BankOcrTests
{
    using System;
    using Xunit;

    public class AsciiDigitTests
    {
        [Fact]
        public void Constructor_NullMatrix_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new AsciiDigit(null));
        }
        
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
        
        [Fact]
        public void Equals_ThreeEqualsThree()
        {
            var expected = new AsciiDigit(new char[3,3] {
                {' ', '_' ,' '},
                {' ', '_', '|'},
                {' ', '_', '|'}
            });
            
            var actual = new AsciiDigit(new char[3,3] {
                {' ', '_' ,' '},
                {' ', '_', '|'},
                {' ', '_', '|'}
            });
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Equals_OneNotEqualsTwo()
        {
            var expected = new AsciiDigit(new char[3,3] {
                {' ', ' ' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            });
            
            var actual = new AsciiDigit(new char[3,3] {
                {' ', '_' ,' '},
                {' ', '_', '|'},
                {'|', '_', ' '}
            });
            
            Assert.NotEqual(expected, actual);
        }
        
        [Fact]
        public void Equals_OneNotEqualsNull()
        {
            var expected = new AsciiDigit(new char[3,3] {
                {' ', ' ' ,' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            });
            
            Assert.False(expected.Equals(null));
        }
    }

    public class AsciiDigit
    {
        private char[,] matrix;
        
        public AsciiDigit(char[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            
            this.matrix = matrix;
        }

        public override string ToString()
        {
            return $"\n{matrix[0, 0]}{matrix[0, 1]}{matrix[0, 2]}\n" +
                   $"{matrix[1, 0]}{matrix[1, 1]}{matrix[1, 2]}\n" +
                   $"{matrix[2, 0]}{matrix[2, 1]}{matrix[2, 2]}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is AsciiDigit other)
            {
                for (int i = 0; i < matrix.Rank + 1; i++)
                {
                    for (int j = 0; j < (matrix.Length / (matrix.Rank + 1)); j++)
                    {
                        if (this.matrix[i, j] != other.matrix[i, j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }
    }
}
