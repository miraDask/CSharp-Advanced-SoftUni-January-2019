namespace _01.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] createCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ListyIterator<string> collection = null;

            if (createCommand.Length != 1)
            {
                List<string> parameters = createCommand.Skip(1).ToList();
                collection = new ListyIterator<string>(parameters);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                switch (input)
                {
                    case "Print":
                        collection.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext()); 
                        break;
                    case "Move":
                        Console.WriteLine(collection.Move());

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
