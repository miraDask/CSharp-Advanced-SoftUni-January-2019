namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] size = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string[][] matrix = new string[size[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[size[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = $"{alphabet[row]}{alphabet[col + row]}{alphabet[row]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
