/*
 * constructor que aceita string
 *
 * Property IsValid
 *
 * 
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
            
            Assert.False(account.IsValid, "664371495 is valid account number");
        }
    }
}
