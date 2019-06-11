using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SportCards
{
    public class SportCards
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, decimal>> cardsReg = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] sportCardsData = input
                    .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (sportCardsData[0] == "check")
                {

                    string cardType = sportCardsData[1];

                    if (cardsReg.ContainsKey(cardType))
                    {
                        Console.WriteLine($"{cardType} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{cardType} is not available!");
                    }

                }
                else
                {
                    string card = sportCardsData[0];
                    string sport = sportCardsData[1];
                    decimal price = decimal.Parse(sportCardsData[2]);

                    if (!cardsReg.ContainsKey(card))
                    {
                        cardsReg[card] = new Dictionary<string, decimal>();
                    }

                    cardsReg[card][sport] = price;

                }

            }

            foreach (var cardKvp in cardsReg.OrderByDescending(c => c.Value.Count))
            {
                string currentCard = cardKvp.Key;
                var sports = cardKvp.Value;

                Console.WriteLine($"{currentCard}:");

                foreach (var sportKvp in sports.OrderBy(x => x.Key))
                {
                    string sport = sportKvp.Key;
                    decimal price = sportKvp.Value;

                    Console.WriteLine($"-{sport} - {price:F2}");
                }
            }
        }
    }
}
