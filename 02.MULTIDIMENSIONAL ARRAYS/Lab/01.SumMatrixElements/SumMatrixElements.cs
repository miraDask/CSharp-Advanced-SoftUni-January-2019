using System;
using System.Linq;

public class SumMatrixElements
{
    public static void Main()
    {
        int[] sequenceOfNums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        int rows = sequenceOfNums[0];
        int cols = sequenceOfNums[1];

        int[,] matrix = new int[rows, cols];
        int sumOfElements = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row,col] = colElements[col];
                sumOfElements += matrix[row, col];
            }
        }

        Console.WriteLine($"{rows}{Environment.NewLine}{cols}{Environment.NewLine}{sumOfElements}");
    }
}

