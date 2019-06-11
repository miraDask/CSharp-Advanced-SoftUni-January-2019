namespace _12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            string pattern = @"([\d]+)";

            Match match = Regex.Match(command, pattern);

            int degreesToRotate = int.Parse(match.Value);

            List<string> lines = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                lines.Add(input);

            }

            int colsCount = GetCount(lines);

            char[][] matrix = new char[lines.Count][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[colsCount];
                string currentRow = lines[row];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col < currentRow.Length)
                    {
                        matrix[row][col] = currentRow[col];
                    }
                    else
                    {
                        matrix[row][col] = ' ';
                    }

                }
            }

            matrix = GetRotatedMatrix(matrix, degreesToRotate);

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] GetRotatedMatrix(char[][] matrix, int degreesToRotate)
        {
            int rotationCoounts = (degreesToRotate / 90) % 4;

            if (rotationCoounts == 0)
            {
                return matrix;
            }

            matrix = RotateMatrix(matrix);

            if (rotationCoounts == 1)
            {
                return matrix;
            }

            matrix = RotateMatrix(matrix);

            if (rotationCoounts == 2)
            {
                return matrix;
            }

            matrix = RotateMatrix(matrix);

            if (rotationCoounts == 3)
            {

                return matrix;
            }

            return matrix;
        }

        private static char[][] RotateMatrix(char[][] matrix)
        {
            char[][] rotatedMatrix = new char[matrix[0].Length][];

            for (int row = 0; row < rotatedMatrix.Length; row++)
            {
                rotatedMatrix[row] = new char[matrix.Length];

                for (int col = 0; col < matrix.Length; col++)
                {
                    rotatedMatrix[row][col] = matrix[matrix.Length - 1 - col][row];
                }
            }

            return rotatedMatrix;
        }

        private static int GetCount(List<string> lines)
        {
            int count = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Length > count)
                {
                    count = lines[i].Length;
                }
            }

            return count;
        }
    }
}
