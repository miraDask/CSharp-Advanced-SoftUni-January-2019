namespace CustomLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {

            // tests:
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(6);
            list.AddFirst(64);
            list.AddFirst(65);

            list.RemoveLast();
            Console.WriteLine(list.Count == 3);
            Console.WriteLine(list.Tail.Vallue);
            list.RemoveFirst();
            Console.WriteLine(list.Head.Vallue);

            list.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            list.AddFirst(9);
            list.AddLast(900);

            var resultArr = list.ToArray();

            Console.WriteLine(string.Join(" ",resultArr));

            Console.WriteLine(list.Contains(9));
        }
    }
}
