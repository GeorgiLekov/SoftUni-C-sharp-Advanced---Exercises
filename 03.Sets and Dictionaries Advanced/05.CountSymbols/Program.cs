using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> occurances = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurances.ContainsKey(input[i]))
                {
                    occurances.Add(input[i], 0);
                }
                occurances[input[i]]++;
            }

            occurances = occurances.OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in occurances)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
