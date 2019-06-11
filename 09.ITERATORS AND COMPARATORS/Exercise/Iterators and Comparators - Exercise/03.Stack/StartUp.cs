namespace _03.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            Stack<string> collection = new Stack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] commandData = input.Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
                string command = commandData[0];

                switch (command)
                {
                    case "Pop":
                        if (collection.Count == 0)
                        {
                            Console.WriteLine("No elements");
                        }
                        else
                        {
                            collection.Pop();
                        }
                        break;
                    case "Push":
                        collection.Push(commandData.Skip(1).ToArray());
                        break;
                    default:
                        break;
                }
            }

            if (collection.Count > 0)
            {
                Console.WriteLine(collection);
                Console.WriteLine(collection);
            }
        }
    }
}
