using System;
using System.Linq;
using System.Text;

public class JaggedArrayModification
{
    public static void Main()
    {
        int rowNumber = int.Parse(Console.ReadLine());
        int[][] jaggedArray = new int[rowNumber][];

        for (int row = 0; row < jaggedArray.Length; row++)
        {
            int[] currentArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            jaggedArray[row] = new int[currentArray.Length];

            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                jaggedArray[row][col] = currentArray[col];
            }
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] commandData = input.Split();
            string command = commandData[0];
            int row = int.Parse(commandData[1]);
            int col = int.Parse(commandData[2]);
            int value = int.Parse(commandData[3]);

            if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
            {
                Console.WriteLine($"Invalid coordinates");
                continue;
            }

            if (command == "Add")
            {
                jaggedArray[row][col] += value;
            }
            else
            {
                jaggedArray[row][col] -= value;
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < jaggedArray.Length; row++)
        {
            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                sb.Append(jaggedArray[row][col] + " ");
            }

            if (row < jaggedArray.Length - 1)
            {
                sb.AppendLine();
            }
            
        }

        Console.WriteLine(sb);
    }
}

