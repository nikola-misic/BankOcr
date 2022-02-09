namespace BankOcr.Logic
{
    public class AccountNumber
    {
        private readonly string accountNumber;
        
        public AccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public bool IsValid => new ChecksumCalculator().Calculate(this.accountNumber) % 11 == 0;
    }
}
