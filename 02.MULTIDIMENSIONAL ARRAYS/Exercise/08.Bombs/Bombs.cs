using System;
using System.Collections.Generic;
using System.Linq;

public class Bombs
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int[][] matrix = new int[size][];

        for (int row = 0; row < matrix.Length; row++)
        {
            int[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix[row] = new int[size];

            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = currentRow[col];
            }
        }

        string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < bombs.Length; i++)
        {
            int[] bomb = bombs[i].
            Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int bombRow = bomb[0];
            int bombCol = bomb[1];

            if (matrix[bombRow][bombCol] > 0)
            {
                DetonateTheBomb(matrix, bombCol, bombRow);

            }

        }

        List<int> aliveCells = GetSum(matrix);
        Console.WriteLine($"Alive cells: {aliveCells.Count}");
        Console.WriteLine($"Sum: {aliveCells.Sum()}");
        Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join(" ", r))));

    }

    private static List<int> GetSum(int[][] matrix)
    {
        List<int> aliveCells = new List<int>();

        for (int row = 0; row < matrix.Length; row++)
        {

            for (int col = 0; col < matrix[row].Length; col++)
            {
                bool cellIsDead = GetCellLifeInfo(row, col, matrix);

                if (cellIsDead == false)
                {
                    aliveCells.Add(matrix[row][col]);
                }
            }
        }

        return aliveCells;
    }

    private static void DetonateTheBomb(int[][] matrix, int bombCol, int bombRow)
    {
        int currentBombValue = matrix[bombRow][bombCol];
        matrix[bombRow][bombCol] = 0;

        

        for (int row = 0; row < matrix.Length; row++)
        {

            for (int col = 0; col < matrix[row].Length; col++)
            {
                bool cellIsDead = GetCellLifeInfo(row,col,matrix);

                if (((row == bombRow - 1 && col == bombCol - 1)
                    || (row == bombRow - 1 && col == bombCol)
                    || (row == bombRow - 1 && col == bombCol + 1)
                    || (row == bombRow && col == bombCol - 1)
                    || (row == bombRow && col == bombCol + 1)
                    || (row == bombRow + 1 && col == bombCol - 1)
                    || (row == bombRow + 1 && col == bombCol)
                    || (row == bombRow + 1 && col == bombCol + 1))
                    && cellIsDead == false)
                {

                    matrix[row][col] -= currentBombValue;

                   
                }

            }
        }
    }

    private static bool GetCellLifeInfo(int row, int col, int[][] matrix)
    {
        if (matrix[row][col] <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
