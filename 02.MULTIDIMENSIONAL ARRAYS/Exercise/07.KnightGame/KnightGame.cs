using System;

public class KnightGame
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        char[][] gameboard = GetGameboard(size);

        int countOfKnightsToRemove = 0;

        while (true)
        {
            bool knightIsRemoved = RemoveKnight(gameboard);

            if (knightIsRemoved == false)
            {
                break;
            }

            countOfKnightsToRemove++;
        }


        Console.WriteLine(countOfKnightsToRemove);

    }

    private static bool RemoveKnight(char[][] gameboard)
    {
        int maxVictories = 0;
        int currentRow = -1;
        int currentCol = -1;

        for (int row = 0; row < gameboard.Length; row++)
        {
            for (int col = 0; col < gameboard[row].Length; col++)
            {
                if (gameboard[row][col] == 'K')
                {

                    int victories = GetVictories(row, col, gameboard);

                    if (victories > maxVictories)
                    {
                        maxVictories = victories;
                        currentCol = col;
                        currentRow = row;
                    }
                }
            }
        }

        if (maxVictories > 0)
        {
            gameboard[currentRow][currentCol] = '0';
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int GetCurrentCellVictory(int currentRow, int currentColl, char[][] gameboard)
    {
        bool isInsideTheGameboard = (currentRow >= 0 && currentRow < gameboard.Length)
            && (currentColl >= 0 && currentColl < gameboard[currentRow].Length)
             && gameboard[currentRow][currentColl] == 'K';

        if (isInsideTheGameboard)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    private static int GetVictories(int row, int col, char[][] gameboard)
    {
        int victories = 0;

        int currentRow = row - 1;
        int currentColl = col - 2;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row + 1;
        currentColl = col - 2;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row + 2;
        currentColl = col - 1;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row + 2;
        currentColl = col + 1;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row + 1;
        currentColl = col + 2;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row - 1;
        currentColl = col + 2;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row - 2;
        currentColl = col + 1;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);

        currentRow = row - 2;
        currentColl = col - 1;
        victories += GetCurrentCellVictory(currentRow, currentColl, gameboard);


        return victories;
    }

    private static char[][] GetGameboard(int size)
    {
        char[][] gameboard = new char[size][];

        for (int row = 0; row < size; row++)
        {
            string input = Console.ReadLine();

            gameboard[row] = new char[size];

            for (int col = 0; col < size; col++)
            {
                gameboard[row][col] = input[col];
            }
        }

        return gameboard;
    }
}

