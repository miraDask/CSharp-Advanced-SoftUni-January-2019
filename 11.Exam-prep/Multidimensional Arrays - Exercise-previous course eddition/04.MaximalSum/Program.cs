namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int MaxSum = int.MinValue;
            string result = string.Empty;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {

                    int[] firstRow = new int[] { matrix[row, col], matrix[row, col + 1],matrix[row, col + 2]};
                    int[] secondRow = new int[] { matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2] };
                    int[] lastRow = new int[] { matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] };

                    int sum = firstRow.Sum() + secondRow.Sum() + lastRow.Sum();

                    if (sum > MaxSum)
                    {
                        MaxSum = sum;
                        result = $"{string.Join(" ", firstRow)}{Environment.NewLine}" +
                            $"{string.Join(" ", secondRow)}{Environment.NewLine}" +
                            $"{string.Join(" ", lastRow)}";
                    }
                }
            }

            Console.WriteLine($"Sum = {MaxSum}");
            Console.WriteLine(result);
        }
    }
}
