using System;
using System.Linq;

public class Miner
{
    public static void Main()
    {
        int sizeOfField = int.Parse(Console.ReadLine());

        string[] commands = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        char[][] mineField = new char[sizeOfField][];

        int coalCount = 0;

        int startRow = -1;
        int startCol = -1;
        int endRow = -1;
        int endCol = -1;

        for (int row = 0; row < sizeOfField; row++)
        {
            char[] curremtRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            mineField[row] = new char[sizeOfField];

            for (int col = 0; col < sizeOfField; col++)
            {
                mineField[row][col] = curremtRow[col];

                if (mineField[row][col] == 'e')
                {
                    endRow = row;
                    endCol = col;
                }
                else if (mineField[row][col] == 's')
                {
                    startRow = row;
                    startCol = col;
                }
                else if (mineField[row][col] == 'c')
                {
                    coalCount++;
                }
            }
        }


        for (int i = 0; i < commands.Length; i++)
        {
            string command = commands[i];

            bool isValidDirection = isValidDirection = GetValidation(command, startRow, startCol, mineField);

            if (isValidDirection)
            {
                int nextRow = -1;
                int nextCol = -1;

                switch (command)
                {
                    case "up":

                        nextRow = startRow - 1;
                        nextCol = startCol;
                        break;

                    case "down":

                        nextRow = startRow + 1;
                        nextCol = startCol;
                        break;

                    case "left":

                        nextRow = startRow;
                        nextCol = startCol - 1;
                        break;

                    case "right":

                        nextRow = startRow;
                        nextCol = startCol + 1;
                        break;
                }

                if (mineField[nextRow][nextCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({nextRow}, {nextCol})");
                    return;
                }
                else if (mineField[nextRow][nextCol] == 'c')
                {
                    coalCount--;
                    mineField[nextRow][nextCol] = 's';
                    mineField[startRow][startCol] = '*';
                    startRow = nextRow;
                    startCol = nextCol;

                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({nextRow}, {nextCol})");
                        return;
                    }

                    // test print:
                    //Console.WriteLine(string.Join(Environment.NewLine, mineField.Select(r => string.Join(" ", r))));
                   // Console.WriteLine();
                }
                else
                {
                    mineField[nextRow][nextCol] = 's';
                    mineField[startRow][startCol] = '*';
                    startRow = nextRow;
                    startCol = nextCol;

                    //test print:
                   // Console.WriteLine(string.Join(Environment.NewLine, mineField.Select(r => string.Join(" ", r))));
                   // Console.WriteLine();
                }
            }
        }

        Console.WriteLine($"{coalCount} coals left. ({startRow}, {startCol})");
    }

    private static bool GetValidation(string command, int startRow, int startCol, char[][] mineField)
    {
        int currentRow = -1;
        int currentCol = -1;

        switch (command)
        {
            case "up":

                currentRow = startRow - 1;
                currentCol = startCol;
                break;

            case "down":

                currentRow = startRow + 1;
                currentCol = startCol;
                break;

            case "left":

                currentRow = startRow ;
                currentCol = startCol -1;
                break;

            case "right":

                currentRow = startRow ;
                currentCol = startCol +1;
                break;
        }

        if (currentRow >= 0 && currentRow < mineField.Length && currentCol >= 0 && currentCol < mineField[currentRow].Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

