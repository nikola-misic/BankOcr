namespace BankOcr.Logic
{
    public enum AccountNumberState
    {
        Valid,
        Error,
        Illegible
    }

    public class AccountNumber
    {
        private readonly string accountNumber;
        private AccountNumberState state;
        
        public AccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;

            if (this.accountNumber.Contains("?"))
            {
                this.state = AccountNumberState.Illegible;
            }
            else
            {
                if (IsValid)
                {
                    this.state = AccountNumberState.Valid;
                }
                else
                {
                    this.state = AccountNumberState.Error;
                }
            }
        }

        public bool IsValid => new ChecksumCalculator().Calculate(this.accountNumber) % 11 == 0;

        public AccountNumberState GetStatus()
        {
            return state;
        }
    }
}
