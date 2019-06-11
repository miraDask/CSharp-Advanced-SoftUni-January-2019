namespace _01.DangerousFloor
{
    using System;
    using System.Linq;

    public class Program
    {
        public static char[][] board = new char[8][];

        static void Main()
        {
            for (int row = 0; row < 8; row++)
            {
                board[row] = Console.ReadLine().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                char figure = input[0];
                int startRow = input[1]-'0';
                int startCol = input[2]-'0';
                int finalRow = input[4]-'0';
                int finalCol = input[5]-'0';


                if (board[startRow][startCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                bool moveIsValid = GetValidation( figure, startCol, startRow, finalCol, finalRow);

                if (!moveIsValid)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                bool moveIsOutOfTheBoard = finalCol < 0 || finalCol > 7 || finalRow < 0 || finalRow > 7;

                if (moveIsOutOfTheBoard)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                Move(figure, startCol, startRow, finalCol, finalRow);
            }
        }

        private static void Move(char figure, int startCol, int startRow, int finalCol, int finalRow)
        {
            board[startRow][startCol] = 'x';
            board[finalRow][finalCol] = figure;
        }

        private static bool GetValidation( char figure, int startCol, int startRow, int finalCol, int finalRow)
        {
            
            int rowDiff = Math.Abs(startRow - finalRow);
            int colDiff = Math.Abs(startCol - finalCol);
            bool isOnDiagonal = rowDiff == colDiff;
            bool isOnTheSameLine = (startRow == finalRow || startCol == finalCol);

            switch (figure)
            {
                case 'K':

                    return (startRow == finalRow && colDiff == 1)
                        || (startCol == finalCol && rowDiff == 1)
                        || (rowDiff == 1 && colDiff == 1);

                case 'P':

                    return finalRow == startRow - 1 && finalCol == startCol;

                case 'Q':

                    return isOnDiagonal || isOnTheSameLine ;

                case 'R':

                    return isOnTheSameLine;

                case 'B':

                    return isOnDiagonal;
            }

            return false;
        }
    }
}
