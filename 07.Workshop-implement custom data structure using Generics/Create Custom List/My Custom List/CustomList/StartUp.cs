namespace CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // test:

            CustomList<int> list = new CustomList<int>();

            list.Add(24);
            list.Add(1);
            list.Add(13);
            int removed = list.RemoveAt(1);
            Console.WriteLine(removed);
            Console.WriteLine(list.Count);

            Console.WriteLine(list);

            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            Console.WriteLine(list);
            list.Insert(2, 100);
            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Contains(5));
            Console.WriteLine(list.Contains(545));
            Console.WriteLine(list);
            list.Swap(2, 5);
            Console.WriteLine(list);

            // list.Insert(7, 4);  //  trow Exeption test
        }
    }
}
