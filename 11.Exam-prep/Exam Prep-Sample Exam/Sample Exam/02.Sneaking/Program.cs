namespace _02.Sneaking
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];
            //int heroRow = -1;
            //int heroCol = -1;
            int[] herroPosition = new int[2];
            int[] bossPosition = new int[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                matrix[row] = new char[line.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = line[col];

                    if (matrix[row][col] == 'S')
                    {
                        herroPosition = new int[] { row, col };
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        bossPosition = new int[] { row, col };
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool bossIsDead = bossPosition[0] == herroPosition[0];

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                
                EnemiesMoves(matrix, herroPosition);

                 bool herroIsDead = HerroCheck(matrix, herroPosition);

                if (herroIsDead)
                {
                    PrintInformationAboutDeadHerro(herroPosition, matrix);
                    break;
                }

                herroPosition = HerroMoves(matrix, herroPosition, command);
                matrix[herroPosition[0]][herroPosition[1]] = 'S';

                bossIsDead = bossPosition[0] == herroPosition[0];
                if (bossIsDead)
                {
                    PrintBossInformation(matrix,bossPosition);
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void PrintBossInformation(char[][] matrix, int[] bossPosition)
        {
            matrix[bossPosition[0]][bossPosition[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
        }

        private static void PrintInformationAboutDeadHerro(int[] position, char[][] matrix)
        {
            matrix[position[0]][position[1]] = 'X';
            Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
            
        }

        private static int[] HerroMoves(char[][] matrix, int[] herroPosition, char command)
        {
            int row = herroPosition[0];
            int col = herroPosition[1];
            matrix[row][col] = '.';
            int finalRow = -1;
            int finalCol = -1;

            if (command == 'U')
            {
                finalRow = row - 1;
                return new int[] { finalRow, col };
            }
            else if (command == 'D')
            {
                finalRow = row + 1;
                return new int[] { finalRow, col };
            }
            else if (command == 'L')
            {
                finalCol = col - 1;
                return new int[] { row, finalCol };
            }
            else if (command == 'R')
            {
                finalCol = col + 1;
                return new int[] { row, finalCol };
            }
            else
            {
                matrix[row][col] = 'S';
                return herroPosition;
            }
        }

        private static void EnemiesMoves(char[][] matrix, int[] herroPosition)
        {

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col == 0 && matrix[row][col] == 'd')
                    {
                        matrix[row][col] = 'b';
                        break;
                    }
                    else if (col == matrix[row].Length - 1 && matrix[row][col] == 'b')
                    {
                        matrix[row][col] = 'd';
                        break;
                    }
                    else
                    {
                        if (matrix[row][col] == 'b')
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            break;
                        }
                        else if (matrix[row][col] == 'd')
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                            break;
                        }
                    }
                }
            }
        }

        private static bool HerroCheck(char[][] matrix, int[] herroPosition)
        {
            int herroRow = herroPosition[0];
            int herroCol = herroPosition[1];

            int cellsCount = matrix[herroRow].Length - (matrix[herroRow].Length - herroCol);
            char[] cellsBeforHerroCell = matrix[herroRow].Take(cellsCount).ToArray();

            if (cellsBeforHerroCell.Any(x => x == 'b'))
            {
                return true;
            }

            cellsCount = matrix[herroRow].Length - herroCol - 1;
            string cellsAfterHerroCell = new string(matrix[herroRow])
                .Substring(herroCol + 1, cellsCount);

            if (cellsAfterHerroCell.Contains('d'))
            {
                return true;
            }

            return false;
        }
    }
}
