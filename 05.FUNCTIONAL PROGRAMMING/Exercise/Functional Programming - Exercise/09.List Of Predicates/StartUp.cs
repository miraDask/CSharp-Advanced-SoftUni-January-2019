namespace _09.List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int limitNum = int.Parse(Console.ReadLine());

            int[] deviders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> resultNums = GetList(limitNum, deviders);

            Console.WriteLine(string.Join(" ", resultNums));
        }

        private static List<int> GetList(int limitNum, int[] deviders)
        {

            List<int> resultList = new List<int>();

            for (int i = 1; i <= limitNum; i++)
            {
                bool isDevisible = false;

                for (int y = 0; y < deviders.Length; y++)
                {
                    int currentDevider = deviders[y];
                    

                    if (!deviderPredicate(i,currentDevider))
                    {
                        isDevisible = false;
                        break;
                    }
                    else
                    {
                        isDevisible = true;
                    }
                }

                if (isDevisible)
                {
                    resultList.Add(i);
                }
            }

            return resultList;
        }

        public static Func<int, int, bool> deviderPredicate = (x, y) => x % y == 0;
    }
}
