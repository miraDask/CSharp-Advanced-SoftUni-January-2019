using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RadioactiveMutantVampireBunnies
{
    public static void Main()
    {
        int[] sizeOfLair = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[][] lair = new char[sizeOfLair[0]][];
        Queue<int[]> bunnies = new Queue<int[]>();

        int startRowIndex = -1;
        int startColIndex = -1;

        for (int row = 0; row < lair.Length; row++)
        {
            char[] currentRow = Console.ReadLine().ToCharArray();


            lair[row] = new char[sizeOfLair[1]];

            for (int col = 0; col < sizeOfLair[1]; col++)
            {
                lair[row][col] = currentRow[col];

                if (lair[row][col] == 'P')
                {
                    startRowIndex = row;
                    startColIndex = col;
                }
                else if (lair[row][col] == 'B')
                {
                    int[] bunny = {row, col};
                    bunnies.Enqueue(bunny);
                }
            }
        }

        char[] commands = Console.ReadLine().ToCharArray();
       

        for (int i = 0; i < commands.Length; i++)
        {
            
            char command = commands[i];
           
            bool isValidDirection = GetValidation(command, startRowIndex, startColIndex, lair);

            if (isValidDirection)
            {
                int nextRow = -1;
                int nextCol = -1;

                switch (command)
                {
                    case 'U':

                        nextRow = startRowIndex - 1;
                        nextCol = startColIndex;
                        break;

                    case 'D':

                        nextRow = startRowIndex + 1;
                        nextCol = startColIndex;
                        break;

                    case 'L':

                        nextRow = startRowIndex;
                        nextCol = startColIndex - 1;
                        break;

                    case 'R':

                        nextRow = startRowIndex;
                        nextCol = startColIndex + 1;
                        break;
                }



                if (lair[nextRow][nextCol] == '.')
                {

                    lair[nextRow][nextCol] = 'P';
                    lair[startRowIndex][startColIndex] = '.';
                    startRowIndex = nextRow;
                    startColIndex = nextCol;

                }
                else if (lair[nextRow][nextCol] == 'B')
                {
                    lair[startRowIndex][startColIndex] = '.';
                    startRowIndex = nextRow;
                    startColIndex = nextCol;
                    bunnies = GetNewBunnies(lair);
                    bool BunniesHasMultiplicated = GetBunnyMultiplication(lair, bunnies);
                    Console.WriteLine(string.Join(Environment.NewLine, lair.Select(r => string.Join("", r))));
                    Console.WriteLine($"dead: {startRowIndex} {startColIndex}");
                    return;
                }

                bool reachedByBunny = GetBunnyMultiplication(lair,bunnies);

                bunnies = GetNewBunnies(lair);
                

                if (reachedByBunny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, lair.Select(r => string.Join("", r))));
                    Console.WriteLine($"dead: {startRowIndex} {startColIndex}");
                    return;
                }
                

            }
        }

        lair[startRowIndex][startColIndex] = '.';
        bunnies = GetNewBunnies(lair);
        bool BunniesMultiplicated = GetBunnyMultiplication(lair,bunnies);

        Console.WriteLine(string.Join(Environment.NewLine, lair.Select(r => string.Join("", r))));
        Console.WriteLine($"won: {startRowIndex} {startColIndex}");
    }

    private static Queue<int[]> GetNewBunnies(char[][] lair)
    {
        Queue<int[]> bunnies = new Queue<int[]>();

        for (int row = 0; row < lair.Length; row++)
        {
          
            for (int col = 0; col < lair[row].Length; col++)
            {
                
                 if (lair[row][col] == 'B')
                {
                    int[] bunny = { row, col };
                    bunnies.Enqueue(bunny);
                }
            }
        }

        return bunnies;
    }

    private static bool GetBunnyMultiplication(char[][] lair, Queue<int[]> bunnies)
    {
        bool playerIsDead = false;


        while (bunnies.Any())
        {
            int[] currentBunny = bunnies.Dequeue();
            int row = currentBunny[0];
            int col = currentBunny[1];

            bool upCellIsInLair = GetValidation('U', row, col, lair);
            bool downCellIsInLair = GetValidation('D', row, col, lair);
            bool leftCellIsInLair = GetValidation('L', row, col, lair);
            bool rightCellIsInLair = GetValidation('R', row, col, lair);

            if (upCellIsInLair)
            {
                if (lair[row - 1][col] == 'P')
                {
                    playerIsDead = true;
                }

                lair[row - 1][col] = 'B';

            }

            if (downCellIsInLair)
            {
                if (lair[row + 1][col] == 'P')
                {
                    playerIsDead = true;
                }

                lair[row + 1][col] = 'B';
            }

            if (leftCellIsInLair)
            {
                if (lair[row][col - 1] == 'P')
                {
                    playerIsDead = true;
                }

                lair[row][col - 1] = 'B';
            }

            if (rightCellIsInLair)
            {
                if (lair[row][col + 1] == 'P')
                {
                    playerIsDead = true;
                }

                lair[row][col + 1] = 'B';
            }
        }
        

        return playerIsDead;
    }

    private static bool GetValidation(char command, int startRow, int startCol, char[][] mineField)
    {
        int currentRow = -1;
        int currentCol = -1;

        switch (command)
        {
            case 'U':

                currentRow = startRow - 1;
                currentCol = startCol;
                break;

            case 'D':

                currentRow = startRow + 1;
                currentCol = startCol;
                break;

            case 'L':

                currentRow = startRow;
                currentCol = startCol - 1;
                break;

            case 'R':

                currentRow = startRow;
                currentCol = startCol + 1;
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

