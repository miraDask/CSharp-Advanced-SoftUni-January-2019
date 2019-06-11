using System;
using System.Linq;

class PrimaryDiagonal
{
    static void Main()
    {
        int sizeOfSquareMatrix = int.Parse(Console.ReadLine());

        int[,] matrix = new int[sizeOfSquareMatrix,sizeOfSquareMatrix];

        int sumOfPrimeryDiagonalElements = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sumOfPrimeryDiagonalElements += matrix[i, i];
        }

        Console.WriteLine(sumOfPrimeryDiagonalElements);
    }
}

