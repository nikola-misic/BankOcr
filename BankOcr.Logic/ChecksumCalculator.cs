namespace BankOcr.Logic
{
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
