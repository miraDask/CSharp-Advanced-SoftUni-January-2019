namespace p01.Even_Lines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        public static void Main()
        {
            List<char> symbols = new List<char> { '-', ',', '.', '!', '?'};

            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    var counter = 0;

                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        if (counter % 2 == 0)
                        {
                            var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            var newLine = new string[words.Length];

                            if (counter != 0)
                            {
                                writer.WriteLine();
                            }

                            for (int i = 0; i < words.Length; i++)
                            {
                                var currentWord = string.Empty;

                                for (int y = 0; y < words[i].Length; y++)
                                {
                                    var currentSymbol = words[i][y];
                                    if (symbols.Any(x => x == currentSymbol))
                                    {
                                        currentWord += '@';
                                    }
                                    else
                                    {
                                        currentWord += currentSymbol;
                                    }
                                }

                                newLine[i] = currentWord;
                            }

                            newLine = newLine.Reverse().ToArray();

                            writer.Write(string.Join(" ", newLine));
                            
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
