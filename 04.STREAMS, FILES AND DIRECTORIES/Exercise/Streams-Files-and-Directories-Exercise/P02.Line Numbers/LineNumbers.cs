namespace P02.Line_Numbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {

                    int count = 1;
                    while (true)
                    {
                        var line = reader.ReadLine();
                        int charCount = 0;
                        int punctuationSymbols = 0;

                        if (line == null)
                        {
                            break;
                        }

                        if (count != 1)
                        {
                            writer.WriteLine();
                        }

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                charCount++;
                            }
                            else if (char.IsPunctuation(line[i]))
                            {
                            
                                punctuationSymbols++;
                            }
                        }

                        writer.Write($"Line {count}: {line} ({charCount})({punctuationSymbols})");

                        count++;
                    }
                }
            }
        }
    }
}
