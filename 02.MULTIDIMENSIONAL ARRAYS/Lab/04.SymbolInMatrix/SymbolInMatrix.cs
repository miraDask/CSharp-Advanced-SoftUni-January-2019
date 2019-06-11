using System;

public class SymbolInMatrix
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        char[,] matrix = new char[size, size];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string currentRow = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        char symbolToFind = char.Parse(Console.ReadLine());

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row,col] == symbolToFind)
                {
                    Console.WriteLine($"({row}, {col})");
                    return;
                }
            }
        }

        Console.WriteLine($"{symbolToFind} does not occur in the matrix");
    }
}

