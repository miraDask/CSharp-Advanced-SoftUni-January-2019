using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class MatrixShuffling
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

        string[,] matrix = new string[dimensions[0], dimensions[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] currentRow = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        while (true)
        {
            string token = Console.ReadLine();

            if (token?.ToLower() == "end")
            {
                break;
            }

            string[] commandLine = token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (commandLine.Length != 5)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                string command = commandLine[0];
                int firstCellRow = int.Parse(commandLine[1]);
                int firstCellCol = int.Parse(commandLine[2]);
                int secondCellRow = int.Parse(commandLine[3]);
                int secondCellCol = int.Parse(commandLine[4]);


                if (commandLine[0] != "swap"
                    || firstCellRow < 0 || firstCellRow >= matrix.GetLength(0) 
                    || firstCellCol < 0 || firstCellCol >= matrix.GetLength(1) 
                    || secondCellRow < 0 || secondCellRow >= matrix.GetLength(0) 
                    || secondCellCol < 0 || secondCellCol >= matrix.GetLength(1) ) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[firstCellRow, firstCellCol];
                matrix[firstCellRow, firstCellCol] = matrix[secondCellRow, secondCellCol];
                matrix[secondCellRow, secondCellCol] = temp;

                StringBuilder sb = new StringBuilder();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row,col] + " ");
                    }

                    Console.WriteLine();
                }

            }

        }
    }
}


