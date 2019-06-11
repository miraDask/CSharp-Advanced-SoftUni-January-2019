

namespace _04.MergeFiles
{
    using System;
    using System.IO;

    public class MergeFiles
    {
        public static void Main()
        {
            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                using (var reader = new StreamReader("FileOne.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine(line);
                    }
                }

                using (var reader = new StreamReader("FileTwo.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
