namespace _01.DataTransfer
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DataTransfer
    {
        public static void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());

             string validationPattern = @"^s:([^;]+);r:([^;]+);m--\""([a-zA-Z ]+)\""$";

            int sumOfTransfer = 0;

            for (int i = 0; i < inputCount; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, validationPattern);

                if (match.Success)
                {
                    string sender = match.Groups[1].ToString();
                    string reciever = match.Groups[2].ToString();
                    string message = match.Groups[3].ToString();

                    string senderName = GetName(sender);
                    string recieverName = GetName(reciever);
                    int dataTransfer = GetDataTransfer(sender, reciever);
                    sumOfTransfer += dataTransfer;

                    Console.WriteLine($"{senderName} says \"{message}\" to {recieverName}");
                    
                }
            }

            Console.WriteLine($"Total data transferred: {sumOfTransfer}MB");
        }

        private static int GetDataTransfer(string sender, string reciever)
        {
            int result = 0;

            for (int i = 0; i < sender.Length; i++)
            {
                if (char.IsDigit(sender[i]))
                {
                    result += int.Parse(sender[i].ToString());
                }
            }

            for (int i = 0; i < reciever.Length; i++)
            {
                if (char.IsDigit(reciever[i]))
                {
                    result += int.Parse(reciever[i].ToString());
                }
            }

            return result;
        }

        private static string GetName(string sender)
        {
            string result = string.Empty;

            for (int i = 0; i < sender.Length; i++)
            {
                if (sender[i] == ' ' || char.IsLetter(sender[i]))
                {
                    result += (char)sender[i];
                }
            }

            return result;
        }
    }
}
