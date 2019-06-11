using System;
using System.Collections.Generic;
using System.Linq;

public class Ranking
{
    public static void Main()
    {
        var passwords = new Dictionary<string, string>();
        var users = new Dictionary<string, Dictionary<string, int>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end of contests")
            {
                break;
            }

            string[] contestData = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
            string contest = contestData[0];
            string password = contestData[1];

            if (!passwords.ContainsKey(contest))
            {
                passwords[contest] = password;
            }
        }


        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end of submissions")
            {
                break;
            }

            string[] contestUsersData = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);

            string contest = contestUsersData[0];
            string password = contestUsersData[1];
            string user = contestUsersData[2];
            int points = int.Parse(contestUsersData[3]);



            if (passwords.ContainsKey(contest) && passwords[contest] == password)
            {
                
                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string,int>();

                }

                if (!users[user].ContainsKey(contest))
                {
                    
                    users[user][contest] = points;

                }
                else if (users[user][contest] < points)
                {
                    users[user][contest] = points;
                }
            }
        }

        foreach (var userKvp in users.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine($"Best candidate is {userKvp.Key} with total {userKvp.Value.Values.Sum()} points." +
            $"{Environment.NewLine}Ranking:");
            break;
        }

        foreach (var userKvp in users.OrderBy(u => u.Key))
        {
            var currentUser = userKvp.Key;
            Console.WriteLine(currentUser);

            foreach (var contestKvp in userKvp.Value.OrderByDescending(x => x.Value))
            {
                var currentContest = contestKvp.Key;
                
                        Console.WriteLine($"#  {currentContest} -> {contestKvp.Value}");
                    
                
            }
        }
    }
}

