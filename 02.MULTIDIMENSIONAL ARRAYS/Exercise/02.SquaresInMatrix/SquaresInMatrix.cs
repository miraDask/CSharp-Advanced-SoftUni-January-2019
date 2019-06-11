using System;
using System.Linq;

public class SquaresInMatrix
{
    public static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries )
            .Select(int.Parse).ToArray();

        char[,] matrix = new char[sizes[0], sizes[1]];

        bool hasMatch = false;
       

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] currentRow = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(char.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        int count = 0;
      

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1]
                    && matrix[row, col + 1] == matrix[row + 1, col]
                    && matrix[row + 1, col] == matrix[row + 1, col + 1])
                {
                    hasMatch = true;
                    count++;
                } 

                
            }
        }

        Console.WriteLine(count);
    }
}

