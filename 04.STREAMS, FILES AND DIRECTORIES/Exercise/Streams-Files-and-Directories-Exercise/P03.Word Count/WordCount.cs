namespace P03.Word_Count
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

            using (var reader = new StreamReader("../../../words.txt"))
            {

                while (true)
                {

                    string word = reader.ReadLine()?.ToLower();

                    if (word == null)
                    {
                        break;
                    }

                    if (!wordsReg.ContainsKey(word))
                    {
                        wordsReg[word] = 0;
                    }
                }
            }

            bool areEqual = false;

            using (var reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                string symbols = " ";

                while (line != null)
                {
                    foreach (var symbol in line)
                    {
                        if (char.IsPunctuation(symbol) && symbol != '\'')
                        {
                            symbols += symbol;
                        }
                    }

                    var splitedLine = line
                        .ToLower()
                        .Split(symbols.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splitedLine)
                    {
                        if (wordsReg.ContainsKey(word))
                        {
                            wordsReg[word]++;
                        }
                    }

                    line = reader.ReadLine();
                }

                wordsReg = wordsReg.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


                using (var expectedReader = new StreamReader("../../../expectedResult.txt"))
                {
                    int countOfExpectedLines = 0;

                    while (true)
                    {
                        var expectedLine = expectedReader.ReadLine();

                        if (expectedLine == null)
                        {
                            break;
                        }
                        
                        int countOfMyOutputLines = 0;

                        foreach (var lineKvp in wordsReg)
                        {
                            if (countOfExpectedLines == countOfMyOutputLines)
                            {
                                if (expectedLine == $"{lineKvp.Key} - {lineKvp.Value}")
                                {
                                    areEqual = true;
                                }
                                else
                                {
                                    areEqual = false;
                                }

                                break;
                            }

                            countOfMyOutputLines++;
                        }

                        countOfExpectedLines++;
                    }
                }
            }

            if (areEqual)
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    foreach (var word in wordsReg)
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }

        }
    }
}
