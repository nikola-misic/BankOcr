/*
 *
 * 111111111 => 1 + 2 + ... + 8 + 9
 * 222222222 => 2 + 4 + ... + 16 + 18
 * 987654321 => 81 + 64 + ... + 4 + 1
 */

namespace BankOcrTests
{
    using Xunit;
    
    public class ChecksumCalculatorTests
    {
        [Fact]
        public void Calculate_AllOnes_ReturnsCorrectResult()
        {
            var expected = 9 + 8 + 7 + 6 + 5 + 4 + 3 + 2 + 1;

            var actual = new ChecksumCalculator().Calculate("111111111");
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Calculate_AllTwos_ReturnsCorrectResult()
        {
            var expected = 18 + 16 + 14 + 12 + 10 + 8 + 6 + 4 + 2;

            var actual = new ChecksumCalculator().Calculate("222222222");
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Calculate_ReverseOrder_ReturnsCorrectResult()
        {
            var expected = 81 + 64 + 49 + 36 + 25 + 16 + 9 + 4 + 1;
        
            var actual = new ChecksumCalculator().Calculate("987654321");
            
            Assert.Equal(expected, actual);
        }
    }

    public class ChecksumCalculator
    {
        public int Calculate(string accountNumber)
        {
            int checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum += (9 - i) * int.Parse(accountNumber[i].ToString());
            }

            return checksum;
        }
    }
}
