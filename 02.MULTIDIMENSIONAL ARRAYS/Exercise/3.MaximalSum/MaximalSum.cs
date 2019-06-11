using System;
using System.Linq;

public class MaximalSum
{
    public static void Main()
    {
        int[] sizesOfMatrix = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[sizesOfMatrix[0], sizesOfMatrix[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] currentRow = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        int maxSum = int.MinValue;
        int[] firstRow = new int[3];
        int[] secondRow = new int[3];
        int[] lastRow = new int[3];

        for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - 3; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    firstRow = new int[] { matrix[row, col], matrix[row, col + 1], matrix[row, col + 2] };
                    secondRow = new int[] { matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2] };
                    lastRow = new int[] { matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] };
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}" +
            $"{ Environment.NewLine}{string.Join(" ",firstRow)}" +
            $"{ Environment.NewLine}{string.Join(" ", secondRow)}" +
            $"{ Environment.NewLine}{string.Join(" ", lastRow)}");
    }
}

