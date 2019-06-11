namespace _02
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int[] positionOfFirst = new int[2];
            int[] positionOfSecond = new int[2];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        positionOfFirst = new int[] { row, col };
                    }
                    else if (matrix[row][col] == 's')
                    {
                        positionOfSecond = new int[] { row, col };
                    }
                }
            }

            bool firstIsAlive = true;
            bool secondIsAlive = true;

            while (firstIsAlive && secondIsAlive)
            {
                string[] commandsArgs = Console.ReadLine().Split();

                string directionForFirst = commandsArgs[0];
                string directionForSecond = commandsArgs[1];

                positionOfFirst = Move(matrix, directionForFirst, positionOfFirst, "first");

                if (matrix.Any(x => x.Any(y => y == 'x')))
                {
                    break;
                }

                positionOfSecond = Move(matrix, directionForSecond, positionOfSecond, "second");

                if (matrix.Any(x => x.Any(y => y == 'x')))
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join("",row));
            }
        }

        private static int[] Move(char[][] matrix, string direction, int[] position, string player)
        {
            int row = position[0];
            int col = position[1];
            char symbol = ' ';

            if (player == "first")
            {
                symbol = 'f';
            }
            else
            {
                symbol = 's';
            }
            bool playerIsDead = false;

            switch (direction)
            {
                case "down":

                    if (row + 1 >= matrix.Length)
                    {
                        playerIsDead = GetInfo(0, col, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[0][col] = 'x';
                            
                        }
                        else
                        {
                            matrix[0][col] = symbol;
                        }

                        return new int[] { 0, col };
                    }
                    else
                    {
                        playerIsDead = GetInfo(row + 1, col, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[row + 1][col] = 'x';
                        }
                        else
                        {
                            matrix[row + 1][col] = symbol;
                        }

                        return new int[] {row + 1, col };
                    }
                    

                case "up":

                    if (row - 1 < 0)
                    {
                        playerIsDead = GetInfo(matrix.Length - 1, col, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[matrix.Length - 1][col] = 'x';
                           
                        }
                        else
                        {
                            matrix[matrix.Length - 1][col] = symbol;
                        }

                        return new int[] { matrix.Length - 1, col };
                    }
                    else
                    {
                        playerIsDead = GetInfo(row - 1, col, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[row - 1][col] = 'x';
                           
                        }
                        else
                        {
                            matrix[row - 1][col] = symbol;
                        }

                        return new int[] { row - 1, col };

                    }
                 

                case "left":

                    if (col - 1 < 0)
                    {
                        playerIsDead = GetInfo(row, matrix[row].Length - 1, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[row][matrix[row].Length - 1] = 'x';
                        }
                        else
                        {
                            matrix[row][matrix[row].Length - 1] = symbol;
                        }

                        return new int[] { row , matrix[row].Length - 1 };

                    }
                    else
                    {
                        playerIsDead = GetInfo(row, col - 1, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[row][col - 1] = 'x';
                        }
                        else
                        {
                            matrix[row][col - 1] = symbol;
                        }

                        return new int[] { row, col - 1 };

                    }
            

                case "right":
                    if (col + 1 >= matrix[row].Length)
                    {
                        playerIsDead = GetInfo(row,0,matrix,symbol);

                        if (playerIsDead)
                        {
                            matrix[row][0] = 'x';
                        }
                        else
                        {
                            matrix[row][0] = symbol;
                        }

                        return new int[] { row, 0 };
                    }
                    else
                    {
                        playerIsDead = GetInfo(row, col + 1, matrix, symbol);

                        if (playerIsDead)
                        {
                            matrix[row][col + 1] = 'x';

                        }
                        else
                        {
                            matrix[row][col + 1] = symbol;
                        }

                        return new int[] { row, col + 1 };

                    }

            }

            return null;
            
        }

        private static bool GetInfo(int row, int col, char[][] matrix, char symbol)
        {
            if (matrix[row][col] != symbol && matrix[row][col] != '*')
            {
                return true;
            }

            return false;
        }
    }
}
