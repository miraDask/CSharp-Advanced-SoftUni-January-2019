namespace _02.RobotCommunication
{
    using System;
    using System.Text.RegularExpressions;

    public class RobotCommunication
    {
        public static void Main()
        {
            string pattern = @"([_,])([a-zA-Z]+)(\d)";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Report")
                {
                    break;
                }

                string decryptedText = string.Empty;

                if (Regex.IsMatch(input,pattern))
                {
                    MatchCollection matches = Regex.Matches(input, pattern);


                    foreach (Match match in matches)
                    {
                        char firstSymbol = char.Parse(match.Groups[1].ToString());
                        string text = match.Groups[2].ToString();
                        int value = int.Parse(match.Groups[3].ToString());


                        for (int i = 0; i < text.Length; i++)
                        {
                            if (firstSymbol == ',') // + value
                            {
                               decryptedText += (char)(text[i] + value);
                            }
                            else       // - value
                            {
                                decryptedText += (char)(text[i] - value);
                            }
                        }

                        decryptedText += ' ';
                    }
                }

                Console.WriteLine(decryptedText);
            }
        }
    }
}
