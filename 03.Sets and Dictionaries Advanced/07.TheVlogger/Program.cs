using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> userNumberOfFolowers = new Dictionary<string, int[]>();
            string inputLines = Console.ReadLine();

            while (inputLines?.ToLower() != "statistics")
            {
                string[] tokens = inputLines.Split(" ");
                string username = tokens[0];
                string command = tokens[1];

                if (command.ToLower() == "joined")
                {
                    if (!vloggers.ContainsKey(username))
                    {
                        vloggers[username] = new List<string>();
                        userNumberOfFolowers[username] = new int[2];
                    }
                }
                else if (command.ToLower() == "followed")
                {
                    string userToFollow = tokens[2];
                    if (vloggers.ContainsKey(username) && vloggers.ContainsKey(userToFollow))
                    {
                        if (!vloggers[userToFollow].Contains(username) && username != userToFollow)
                        {
                            vloggers[userToFollow].Add(username);
                            userNumberOfFolowers[userToFollow][0]++;
                            userNumberOfFolowers[username][1]++;
                        }
                    }
                }

                inputLines = Console.ReadLine();
            }

            Console.WriteLine($"The V - Logger has a total of {vloggers.Count} vloggers in its logs.");

            Dictionary<string, int[]> orderedUserAndFollowers = userNumberOfFolowers.OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value);

            int count = 1;
            string userToRemove = "";
            foreach (var vlogger in orderedUserAndFollowers)
            {
                userToRemove = vlogger.Key;
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
                count++;
                if (vloggers[vlogger.Key].Count > 0)
                {
                    foreach (var follower in vloggers[vlogger.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"* {follower}");
                    }
                }
                break;
            }

            orderedUserAndFollowers.Remove(userToRemove);

            foreach (var kvp in orderedUserAndFollowers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                count++;
            }
        }
    }
}