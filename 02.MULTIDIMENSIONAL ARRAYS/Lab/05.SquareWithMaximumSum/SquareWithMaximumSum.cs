using System;
using System.Linq;

public class SquareWithMaximumSum
{
    public static void Main()
    {
        int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int[,] matrix = new int[size[0], size[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        int maxSum = int.MinValue;
        int[] firstRow = new int[2];
        int[] secondRow = new int[2];

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    firstRow[0] = matrix[row, col];
                    firstRow[1] = matrix[row, col + 1];
                    secondRow[0] = matrix[row + 1, col];
                    secondRow[1] = matrix[row + 1, col + 1];
                }
            }
        }

        Console.WriteLine($"{string.Join(" ", firstRow)}{Environment.NewLine}" +
            $"{string.Join(" ", secondRow)}{Environment.NewLine}{maxSum}");
    }
}

