namespace _11.The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> invitedGuests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filteredGuestList = new List<string>();
            filteredGuestList.InsertRange(0, invitedGuests);

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] tokens = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);


                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                Func<string,string,bool> filter = GetFunc(filterType);

                if (command.Contains("Add"))
                {
                    filteredGuestList = filteredGuestList.Where(x => !filter(x, filterParameter)).ToList();
                }
                else if (command.Contains("Remove"))
                {
                    List<string> guestsToAdd = invitedGuests.Where(x => filter(x, filterParameter)).ToList();

                    foreach (var guest in guestsToAdd)
                    {
                        filteredGuestList.Add(guest);
                    }
                }

                input = Console.ReadLine();
            }

            List<string> finalList = GetList(invitedGuests, filteredGuestList);

            Console.WriteLine(string.Join(" ",finalList));
        }

        private static List<string> GetList(List<string> invitedGuests, List<string> filteredGuestList)
        {
            List<string> finalList = new List<string>();
            finalList.AddRange(invitedGuests);

            foreach (var name in invitedGuests)
            {
                if (!filteredGuestList.Contains(name))
                {
                   finalList.Remove(name);
                }
            }

            return finalList;
           
        }

        private static Func<string,string,bool> GetFunc(string filterType)
        {
            switch (filterType)
            {
                case "Starts with": return (x, y) => x.StartsWith(y);
                case "Ends with": return (x, y) => x.EndsWith(y);
                case "Length": return (x, y) => x.Length == int.Parse(y);
                case "Contains": return (x, y) => x.Contains(y);
                default: return null;
                    
            }
        }
    }
}
