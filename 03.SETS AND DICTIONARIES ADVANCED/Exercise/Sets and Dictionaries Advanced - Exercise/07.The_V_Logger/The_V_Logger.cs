using System;
using System.Collections.Generic;
using System.Linq;

public class The_V_Logger
{
    public static void Main()
    {
        // loggerName => followersList
        Dictionary<string, List<string>> vloggersReg = new Dictionary<string, List<string>>();

        // name => followingsCount
        Dictionary<string, int> followings = new Dictionary<string, int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Statistics")
            {
                break;
            }

            string[] commandLine = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = commandLine[1];

            if (command == "joined")
            {
                string vloggerName = commandLine[0];

                if (!vloggersReg.ContainsKey(vloggerName))
                {
                    vloggersReg[vloggerName] = new List<string>();
                    followings[vloggerName] = 0;
                }

            }
            else
            {
                string follower = commandLine[0];
                string vlogger = commandLine[2];

                if (vloggersReg.ContainsKey(vlogger)
                    && vloggersReg.ContainsKey(follower)
                    && follower != vlogger
                    && vloggersReg[vlogger].Contains(follower) == false)
                {
                    followings[follower]++;
                    vloggersReg[vlogger].Add(follower);
                }
            }

        }

        // vlogger -> followers/followings
        Dictionary<string, int[]> finalReg = new Dictionary<string, int[]>();

        foreach (var pair in vloggersReg)
        {
            string vlogger = pair.Key;
            finalReg[vlogger] = new int[2];
            finalReg[vlogger][0] = pair.Value.Count;
            finalReg[vlogger][1] = followings[vlogger];

        }

        Console.WriteLine($"The V-Logger has a total of {vloggersReg.Count} vloggers in its logs.");

        int count = 1;

        foreach (var vloggerKvp in finalReg.OrderByDescending(v => v.Value[0]).ThenBy(v => v.Value[1]))
        {
            Console.WriteLine($"{count}. {vloggerKvp.Key} : {vloggerKvp.Value[0]} followers, {vloggerKvp.Value[1]} following");

            if (count == 1)
            {

                foreach (var follower in vloggersReg[vloggerKvp.Key].OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            count++;
        }
    }
}

