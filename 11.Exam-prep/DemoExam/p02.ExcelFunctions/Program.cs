namespace p02.ExcelFunctions
{
    using System;
    using System.Linq;

    public class Program
    {
        public static string[] header;

        public static void Main()
        {
            int tableRows = int.Parse(Console.ReadLine());
            string[][] table = new string[tableRows][];


            for (int row = 0; row < tableRows; row++)
            {
                table[row] = Console.ReadLine().Split(", ").ToArray();

                if (row == 0)
                {
                    header = table[row];
                }
            }

            string[] splitedCommand = Console.ReadLine().Split();

            string command = splitedCommand[0];

            switch (command)
            {
                case "hide":
                    string headerData = splitedCommand[1];
                    int col = Array.IndexOf(header, headerData);

                    foreach (var row in table)
                    {
                        Console.WriteLine(string.Join(" | ", row.Where((x, y) => y != col)));

                    }

                    break;

                case "sort":

                    string headerForSorting = splitedCommand[1];
                    int coll = Array.IndexOf(header, headerForSorting);

                    Console.WriteLine(string.Join(" | ", table[0]));

                    foreach (var row in table.Where(r => r != table[0]).OrderBy(x => x[coll]))
                    {
                        Console.WriteLine(string.Join(" | ", row));

                    }

                    break;

                case "filter":
                    string headerType = splitedCommand[1];
                    string headerValue = splitedCommand[2];
                    int colOfHeader = Array.IndexOf(header, headerType);

                    Console.WriteLine(string.Join(" | ", table[0]));

                    foreach (var currentRow in table.Where(x => x[colOfHeader] == headerValue))
                    {
                        Console.WriteLine(string.Join(" | ", currentRow));
                    }

                    break;
            }
        }
    }
}
