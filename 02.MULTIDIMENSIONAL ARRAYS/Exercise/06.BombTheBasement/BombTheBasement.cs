using System;
using System.Linq;

class BombTheBasement
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

        int[,] matrix = new int[dimensions[0], dimensions[1]];

        int[] bombParameters = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

        int targetRow = bombParameters[0];
        int targetCol = bombParameters[1];
        int radius = bombParameters[2];
        int tempRowCounter = targetRow;
        int count = 0;

        for (int row = 0; row < radius + 1; row++)
        {

            for (int col = (targetCol - radius) + count; col <= targetCol + radius - count; col++)
            {

                if (col == matrix.GetLength(1) || col < 0)
                {
                    continue;
                }

                matrix[tempRowCounter, col] = 1;

                if (col > (2 * radius + 1) - count)
                {
                    break;
                }

            }

            tempRowCounter++;
            count++;

            if (tempRowCounter == matrix.GetLength(0))
            {
                break;
            }

        }

        count = 0;

        for (int row = targetRow - radius; row < targetRow; row++)
        {

            if (row < 0)
            {
                count++;
                continue;
            }

            for (int col = targetCol - count; col <= targetCol + count; col++)
            {
                if (col < 0)
                {
                    continue;
                }

                matrix[row, col] = 1;
            }

            count++;
        }

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == 1 && matrix[row - 1, col] == 0)
                {
                    int n = 1;

                    while (matrix[row - n, col] == 0)
                    {

                        matrix[row, col] = 0;

                        n++;

                        if (row - n < 0 || matrix[row - n, col] == 1)
                        {
                            matrix[row - n + 1, col] = 1;
                            break;
                        }
                        else if (matrix[row - n, col] == 0)
                        {
                            continue;
                        }
                    }


                }
            }


        }


        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }




    }
}

