using System;
using System.Text;

public class PascalTriangle
{
    public static void Main()
    {
        int numOfRows = int.Parse(Console.ReadLine());

        long[][] paskalTriangle = new long[numOfRows][];

        for (int row = 0; row < paskalTriangle.Length; row++)
        {
            paskalTriangle[row] = new long[row + 1];

            for (int col = 0; col < paskalTriangle[row].Length; col++)
            {
                if (col == 0 || col == paskalTriangle[row].Length - 1)
                {
                    paskalTriangle[row][col] = 1;
                }
                else
                {
                    paskalTriangle[row][col] = paskalTriangle[row - 1][col - 1] + paskalTriangle[row - 1][col];
                }
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < paskalTriangle.Length; row++)
        {
            for (int col = 0; col < paskalTriangle[row].Length; col++)
            {
                sb.Append(paskalTriangle[row][col] + " ");
            }

            if (row < paskalTriangle.Length - 1)
            {
                sb.AppendLine();
            }

        }

        Console.WriteLine(sb);
    }
}

