namespace _07.LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[inputCount][];
            int[][] secondMatrix = new int[inputCount][];

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    for (int row = 0; row < firstMatrix.Length; row++)
                    {
                        firstMatrix[row] = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                    }
                }
                else
                {
                    for (int row = 0; row < secondMatrix.Length; row++)
                    {
                        secondMatrix[row] = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Reverse()
                            .ToArray();
                    }
                }
            }

            bool newMatrixIsRectangular = true;
            int cellsInNewMatrix = 0;
            int newMatrixRowsLenght = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int row = 0; row < secondMatrix.Length; row++)
            {
                int currentRowLenght = firstMatrix[row].Length + secondMatrix[row].Length;

                if (newMatrixRowsLenght != currentRowLenght)
                {
                    newMatrixIsRectangular = false;
                }
                
                cellsInNewMatrix += currentRowLenght;
            }

            if (newMatrixIsRectangular == false)
            {
                Console.WriteLine($"The total number of cells is: {cellsInNewMatrix}");
                return;
            }

            for (int row = 0; row < inputCount; row++)
            {
                int[] result = firstMatrix[row].Concat(secondMatrix[row]).ToArray();
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
        }
    }
}
