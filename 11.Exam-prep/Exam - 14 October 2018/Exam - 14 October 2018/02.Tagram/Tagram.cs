namespace _02.Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tagram
    {
        public static void Main()
        {
            var usersRegister = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] userData = input.Split(new char[] { ' ', '-', '>' }
                , StringSplitOptions.RemoveEmptyEntries);

                if (userData[0] == "ban")
                {
                    string bannedUser = userData[1];

                    if (usersRegister.ContainsKey(bannedUser))
                    {
                        usersRegister.Remove(bannedUser);
                    }
                }
                else
                {
                    string username = userData[0];
                    string tag = userData[1];
                    long likes = long.Parse(userData[2]);

                    if (!usersRegister.ContainsKey(username))
                    {
                        usersRegister[username] = new Dictionary<string, long>();
                    }

                    var currentUser = usersRegister[username];

                    if (!currentUser.ContainsKey(tag))
                    {
                        currentUser[tag] = 0;
                    }

                    currentUser[tag] += likes;
                }
            }

            foreach (var userKvp in usersRegister.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                string username = userKvp.Key;
                var tags = userKvp.Value;

                Console.WriteLine($"{username}");

                foreach (var tagKvp in tags)
                {
                    Console.WriteLine($"- {tagKvp.Key}: {tagKvp.Value}");
                }
            }
        }
    }
}
