namespace _09.Crossfire
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int count = 1;

            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = count;
                    count++;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Nuke it from orbit")
                {
                    break;
                }

                int[] destructionRange = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                matrix = MatrixDestruct(matrix, destructionRange);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static int[][] MatrixDestruct(int[][] matrix, int[] destructionRange)
        {
            int targetRow = destructionRange[0];
            int targetCol = destructionRange[1];
            int radius = destructionRange[2];

            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IndexesAreValid(row, targetCol, matrix))
                {
                    matrix[row][targetCol] = -1;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IndexesAreValid(targetRow, col, matrix))
                {
                    matrix[targetRow][col] = -1;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Any(n => n == -1))
                {
                    matrix[row] = matrix[row].Where(n => n > 0).ToArray();
                }
            }

            return matrix.Where(x => x.Length > 0).ToArray();
        }

        private static bool IndexesAreValid(int row, int targetCol, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && targetCol >= 0 && targetCol < matrix[row].Length;
        }
    }
}
