/*
 * constructor que aceita string
 *
 * Property IsValid
 *
 * 
 */

namespace BankOcrTests
{
    using Xunit;

    public class AccountNumberTests
    {
        [Fact]
        public void CreateInstance()
        {
            new AccountNumber("");
        }
    }

    public class AccountNumber
    {
        public AccountNumber(string accountNumber)
        {
            
        }
    }
}
