/*
 * constructor que aceita string
 *
 * Property IsValid
 *
 * GetStatus
 * - valid number
 * - invalid number
 * - illegible number
 */

namespace BankOcrTests
{
    using BankOcr.Logic;
    using Xunit;

    public class AccountNumberTests
    {
        [Fact]
        public void IsValid_ValidAccount()
        {
            var account = new AccountNumber("457508000");
            
            Assert.True(account.IsValid, "457508000 is not valid account number");
        }
        
        [Fact]
        public void IsValid_InvalidAccountNumber()
        {
            var account = new AccountNumber("664371495");
            
            Assert.False(account.IsValid, "664371495 is not valid account number");
        }

        [Fact]
        public void GetStatus_ValidAccountNumber()
        {
            var actual = new AccountNumber("457508000").GetStatus();
            
            Assert.Equal(AccountNumberState.Valid, actual);
        }
        
        [Fact]
        public void GetStatus_InvalidAccountNumber()
        {
            var actual = new AccountNumber("664371495").GetStatus();
            
            Assert.Equal(AccountNumberState.Error, actual);
        }
        
        [Fact]
        public void GetStatus_IllegibleAccountNumber()
        {
            var actual = new AccountNumber("86110??36").GetStatus();
            
            Assert.Equal(AccountNumberState.Illegible, actual);
        }
    }
}
