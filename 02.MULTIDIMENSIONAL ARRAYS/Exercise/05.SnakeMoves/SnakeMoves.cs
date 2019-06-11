using System;
using System.Collections.Generic;
using System.Linq;

class SnakeMoves
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string input = Console.ReadLine();
        Queue<char> snake = new Queue<char>(input);

        char[,] matrix = new char[sizes[0], sizes[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (snake.Any() == false)
                {
                    snake = new Queue<char>(input);

                }

                matrix[row, col] = snake.Dequeue();

                Console.Write(matrix[row, col]);

            }

            Console.WriteLine();
        }
    }
}

