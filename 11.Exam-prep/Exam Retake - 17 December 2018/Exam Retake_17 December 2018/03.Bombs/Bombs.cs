namespace _03.Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bombs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                int[] numSequence = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[size];

                for (int col = 0; col < size; col++)
                {
                    matrix[row][col] = numSequence[col];
                }
            }

            string[] coordinatesData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<int> aliveCells = new List<int>();

            for (int i = 0; i < coordinatesData.Length; i++)
            {
                int[] bombCoordinates = coordinatesData[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];
                int bomb = matrix[bombRow][bombCol];

                if (bomb > 0)
                {


                    int targetRow = bombRow - 1;
                    int targetCol = bombCol - 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow - 1;
                    targetCol = bombCol;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow - 1;
                    targetCol = bombCol + 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow;
                    targetCol = bombCol - 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow;
                    targetCol = bombCol + 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow + 1;
                    targetCol = bombCol - 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow + 1;
                    targetCol = bombCol;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    targetRow = bombRow + 1;
                    targetCol = bombCol + 1;
                    GetValidation(targetRow, targetCol, matrix, bomb);

                    matrix[bombRow][bombCol] = 0;
                }
            }

            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    if (element > 0)
                    {
                        aliveCells.Add(element);
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells.Count}" +
                $"{Environment.NewLine}Sum: {aliveCells.Sum()}");
            Console.WriteLine(string.Join(Environment.NewLine
                , matrix.Select(r => string.Join(" ", r))));
        }

        private static void GetValidation(int targetRow, int targetCol, int[][] matrix, int bomb)
        {
            if ((targetRow >= 0 && targetRow < matrix.Length)
                && targetCol >= 0 && targetCol < matrix[targetRow].Length
                && matrix[targetRow][targetCol] > 0)
            {
                matrix[targetRow][targetCol] -= bomb;
            }

        }
    }
}
