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
    1 == 1
    3 == 3
    1 != 2
 
 */

namespace BankOcrTests
{
    using System;
    using BankOcr.Logic;
    using Xunit;

    public class AsciiDigitTests
    {
        [Fact]
        public void Constructor_NullMatrix_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new AsciiDigit(null));
        }
        
        [Fact]
        public void Constructor_MatrixWithMoreRows_ThrowsException()
        {
            Assert.Throws<InvalidDigitSizeException>(() => new AsciiDigit(new char[2,4]));
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
        
        [Fact]
        public void GetHashCode_OneEqualsOne()
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
            
            Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
        }
        
        [Fact]
        public void GetHashCode_ThreeEqualsThree()
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
            
            Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
        }
        
        [Fact]
        public void GetHashCode_OneNotEqualsTwo()
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
            
            Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
        }
    }
}
