namespace _06.TargetPractice
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] matrix = new char[size[0]][];

            string snake = Console.ReadLine();

            int symbolsCount = snake.Length;
            int indexOfSymbol = 0;

            int rowsCount = 0;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {

                matrix[row] = new char[size[1]];

                if (rowsCount % 2 == 0)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (symbolsCount == 0)
                        {
                            symbolsCount = snake.Length;
                            indexOfSymbol = 0;
                        }

                        matrix[row][col] = snake[indexOfSymbol];
                        indexOfSymbol++;
                        symbolsCount--;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (symbolsCount == 0)
                        {
                            symbolsCount = snake.Length;
                            indexOfSymbol = 0;
                        }

                        matrix[row][col] = snake[indexOfSymbol];
                        indexOfSymbol++;
                        symbolsCount--;
                    }
                }

                rowsCount++;
            }

            int[] bombArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombRow = bombArgs[0];
            int bombCol = bombArgs[1];
            int radius = bombArgs[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));

                    if (distance <= radius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }


            for (int col = 0; col < size[1]; col++)
            {
                string elements = string.Empty;

                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements += matrix[row][col];
                    }
                }

                int count = 0;
                for (int r = matrix.Length - 1; r >= 0; r--)
                {
                    if (count < elements.Length)
                    {
                        matrix[r][col] = elements[count];
                        count++;
                    }
                    else
                    {
                        matrix[r][col] = ' ';
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}

