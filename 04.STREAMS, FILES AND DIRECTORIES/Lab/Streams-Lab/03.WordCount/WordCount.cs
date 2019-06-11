namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            Dictionary<string, int> wordsReg = new Dictionary<string, int>();
            List<string> words = new List<string>();

            using (var reader = new StreamReader("words.txt"))
            {
                words = reader.ReadLine()
                   .ToLower()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .ToList();

                foreach (var word in words)
                {
                    wordsReg[word] = 0;
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {

                    foreach (var word in words)
                    {
                        if (line.ToLower().Contains(word))
                        {
                            wordsReg[word]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in wordsReg.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
