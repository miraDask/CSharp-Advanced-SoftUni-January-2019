namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[size[0]][];
            int number = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[size[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = number++;
                }
            }

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                int startIndex = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];                   // up,down for cols;  left,right for rows
                int movesCount = int.Parse(commandArgs[2]);
                movesCount = direction == "up" || direction == "down" ? movesCount % matrix.Length : movesCount % matrix[0].Length;

                 Move(matrix, startIndex, movesCount, direction);
               
            }
            
            StringBuilder result = ShuffleMatrix(matrix);
            Console.WriteLine(result);
        }

        private static StringBuilder ShuffleMatrix(int[][] matrix)
        {
            StringBuilder result = new StringBuilder();
           
            int value = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == value)
                    {
                        result.AppendLine("No swap required");
                    }
                    else
                    {
                        int indexOfElement = -1;
                        int elementRow = -1;

                        for (int r = 0; r < matrix.Length; r++)
                        {
                            if (matrix[r].Any(x => x == value))
                            {
                                indexOfElement = Array.IndexOf(matrix[r],value);
                                elementRow = r;
                                break;
                            }
                        }

                        matrix[elementRow][indexOfElement] = matrix[row][col];
                        matrix[row][col] = value;
                        result.AppendLine($"Swap ({row}, {col}) with ({elementRow}, {indexOfElement})");
                    }
                    value++;
                }
            }

            return result;
        }

        private static void Move(int[][] matrix, int startIndex, int movesCount, string direction)
        {
            for (int i = 0; i < movesCount; i++)
            {
                int temp = int.MinValue;

                if (direction == "up")
                {
                    temp = matrix[0][startIndex];

                    for (int row = 0; row < matrix.Length - 1; row++)
                    {
                        matrix[row][startIndex] = matrix[row + 1][startIndex];
                    }

                    matrix[matrix.Length - 1][startIndex] = temp;
                }
                else if (direction == "down")
                {
                    temp = matrix[matrix.Length - 1][startIndex];

                    for (int row = matrix.Length - 1; row > 0; row--)
                    {
                        matrix[row][startIndex] = matrix[row - 1][startIndex];
                    }

                    matrix[0][startIndex] = temp;
                }
                else if (direction == "left")
                {
                    temp = matrix[startIndex][0];

                    for (int col = 0; col < matrix[0].Length - 1; col++)
                    {
                        matrix[startIndex][col] = matrix[startIndex][col + 1];
                    }

                    matrix[startIndex][matrix[0].Length - 1] = temp;
                }
                else if (direction == "right")
                {
                    temp = matrix[startIndex][matrix[0].Length - 1];

                    for (int col = matrix[0].Length - 1; col > 0; col--)
                    {
                        matrix[startIndex][col] = matrix[startIndex][col - 1];
                    }

                    matrix[startIndex][0] = temp;
                }
            }
        }
    }
}
