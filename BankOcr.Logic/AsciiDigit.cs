namespace BankOcr.Logic
{
    using System;
    using System.Text;

    public class AsciiDigit
    {
        private readonly char[,] matrix;
        
        public AsciiDigit(char[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                throw new InvalidDigitSizeException(matrix.GetLength(0), matrix.GetLength(1));
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
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
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

        public override int GetHashCode()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                }
            }

            return sb.ToString().GetHashCode();
        }
    }
}
