namespace _02.Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] room = new char[rowsCount][];

            int[] samPosition = new int[2];  // [0] - row, [1] - col
            int bossRow = -1;
            int bossCol = -1;

            for (int row = 0; row < rowsCount; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                room[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {

                    room[row][col] = currentRow[col];

                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                    else if (room[row][col] == 'N')
                    {
                        bossRow = row;
                        bossCol = col;
                    }
                }
            }

            string commandsSequence = Console.ReadLine();
            Queue<char> commans = new Queue<char>(commandsSequence);

            while (commans.Any())
            {
                
                EnemiesMoves(room);

              bool  samIsAlive = IsSamAlive(room, samPosition);

                if (!samIsAlive)
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    room[samPosition[0]][samPosition[1]] = 'X';
                    break;
                }

                char currentCommand = commans.Dequeue();

                int[] samsNewPosition = new int[2];

                if (currentCommand != 'W')
                {
                    samsNewPosition = SamMoves(samPosition, currentCommand, room);
                    samPosition = samsNewPosition;

                    if (samPosition[0] == bossRow)
                    {
                        room[bossRow][bossCol] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        break;
                    }
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static int[] SamMoves(int[] samPosition, char currentCommand, char[][] room)
        {
            int samsRow = samPosition[0];
            int samsCol = samPosition[1];

            switch (currentCommand)
            {
                case 'U':
                    room[samsRow - 1][samsCol] = 'S';
                    room[samsRow][samsCol] = '.';
                    samsRow = samsRow - 1;
                    break;
                case 'D':
                    room[samsRow + 1][samsCol] = 'S';
                    room[samsRow][samsCol] = '.';
                    samsRow = samsRow + 1;
                    break;
                case 'L':
                    room[samsRow][samsCol - 1] = 'S';
                    room[samsRow][samsCol] = '.';
                    samsCol = samsCol - 1;
                    break;
                case 'R':
                    room[samsRow][samsCol + 1] = 'S';
                    room[samsRow][samsCol] = '.';
                    samsCol = samsCol + 1;
                    break;
                default:
                    break;
            }

            return new int[] { samsRow, samsCol };
        }

        private static bool IsSamAlive(char[][] room, int[] samPosition)
        {
            int samsRow = samPosition[0];
            int samsCol = samPosition[1];

            for (int col = 0; col < samsCol; col++)
            {
                char enemySymbol = room[samsRow][col];

                if (enemySymbol == 'b')
                {
                    return false;
                }
            }

            for (int col = samsCol + 1; col < room[samsRow].Length; col++)
            {
                char enemySymbol = room[samsRow][col];

                if (enemySymbol == 'd')
                {
                    return false;
                }
            }

            return true;
        }

        private static void EnemiesMoves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Any(x => x == 'b' || x == 'd'))
                {

                    for (int col = 0; col < room[row].Length; col++)
                    {
                        char enenmy = room[row][col];
                        if (enenmy == 'b')
                        {
                            if (col == room[row].Length - 1)
                            {
                                room[row][col] = 'd';
                            }
                            else
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                            }

                            break;
                        }
                        else if (enenmy == 'd')
                        {
                            if (col == 0)
                            {
                                room[row][col] = 'b';
                            }
                            else
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}
