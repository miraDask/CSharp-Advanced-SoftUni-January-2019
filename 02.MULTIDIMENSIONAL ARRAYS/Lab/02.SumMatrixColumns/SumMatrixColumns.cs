using System;
using System.Linq;

class SumMatrixColumns
{
    static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        int rows = matrixSize[0];
        int cols = matrixSize[1];

        int[,] matrix = new int[rows, cols];


        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colsElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colsElements[col];
            }
        }

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int sumOfCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumOfCol += matrix[row,col];
            }

            Console.WriteLine(sumOfCol);
        }
    }
}

