using System;
using System.Linq;

public class DiagonalDifference
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] rowOfElements = Console.ReadLine()
                .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowOfElements[col];
            }
        }


        long primaryDiagonalSum = 0;
        long secondaryDiagonalSum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            primaryDiagonalSum += matrix[i, i];
            secondaryDiagonalSum += matrix[i, matrix.GetLength(0) - 1 - i];
        }

        // working solution with with while loop;

        //int currentRow = 0;
        //int currentCow = 0;

        //while (true)
        //{
        //    if (currentRow < 0 
        //        || currentRow >= matrix.GetLength(0)
        //        || currentCow < 0
        //        || currentCow >= matrix.GetLength(1))
        //    {
        //        break;
        //    }

        //    primaryDiagonalSum += matrix[currentRow, currentCow];
        //    secondaryDiagonalSum += matrix[currentRow, matrix.GetLength(1) - 1 - currentRow];

        //    currentRow++;
        //    currentCow++;
        //}

        long diagonalDifference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

        Console.WriteLine(diagonalDifference);
    }
}

