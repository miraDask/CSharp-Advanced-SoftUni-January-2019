namespace _01.OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    int count = 0;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        

                        if (count % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                    }
                }
            }
        }
    }
}
