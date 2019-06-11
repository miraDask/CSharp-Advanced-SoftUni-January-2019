namespace _03.CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 0; i < lineCount; i++)
            {
                text += Console.ReadLine();
            }

            string patern = @"\[[^{}\[\]]+\]|{[^{}\[\]]+}";

            MatchCollection matches = Regex.Matches(text, patern);

            string decryptedText = string.Empty;

            foreach (var match in matches)
            {
                string elementsToString = match.ToString();
                string numberSequence = Regex.Match(elementsToString, @"[\d]+").ToString();

                if (numberSequence.Length % 3 != 0)
                {
                    continue;
                }

                int length = elementsToString.Length;
                int[] numbers = GetNumbers(numberSequence);
                numbers = numbers.Select(x => x - length).ToArray();
                char[] characters = numbers.Select(x => (char)x).ToArray();
                decryptedText += new string(characters);

            }

            Console.WriteLine(decryptedText);
        }

        private static int[] GetNumbers(string numberSequence)
        {
            int[] result = new int[numberSequence.Length / 3];

            for (int i = 0; i < result.Length; i++)
            {
                int startIndex = i * 3;
                int endIndex = startIndex + 3;
                string temp = string.Empty;

                for (int j = startIndex; j < endIndex; j++)
                {
                    temp += numberSequence[j];
                    
                }

                result[i] = int.Parse(temp);
            }

            return result;
        }
    }
}
