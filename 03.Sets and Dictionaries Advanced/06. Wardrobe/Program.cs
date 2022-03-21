using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string[] items = command[1].Split(",");

                string currentColor = command[0];

                if (!wardrobe.ContainsKey(command[0]))
                {
                    wardrobe.Add(command[0], new Dictionary<string, int>());
                }
                foreach(var item in items)
                {
                    if (!wardrobe[currentColor].ContainsKey(item))
                    {
                        wardrobe[currentColor].Add(item, 0);
                    }
                    wardrobe[currentColor][item]++;
                }
            }
            string[] search = Console.ReadLine().Split();

            foreach(var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach(var item in color.Value)
                {
                    if (search[0] == color.Key && search[1] == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
