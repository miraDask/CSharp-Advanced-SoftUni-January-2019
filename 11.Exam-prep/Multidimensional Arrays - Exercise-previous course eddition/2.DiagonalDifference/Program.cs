namespace _2.DiagonalDifference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            long firstDiagonalSum = GetDiagonalSum(matrix, "first");
            long secondDiagonalSum = GetDiagonalSum(matrix, "second");
            long diff = Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(diff);
        }

        private static long GetDiagonalSum(int[][] matrix, string v)
        {
            long sum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                if (v == "first")
                {
                    sum += matrix[row][row];
                }
                else
                {
                    sum += matrix[row][matrix[row].Length - 1 - row];
                }

            }
            return sum;
        }
    }
}
