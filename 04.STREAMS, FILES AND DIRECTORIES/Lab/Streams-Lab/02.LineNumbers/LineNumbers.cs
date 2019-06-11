namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    int count = 1;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"{count++}. {line}");
                    }
                }
            }
        }
    }
}
