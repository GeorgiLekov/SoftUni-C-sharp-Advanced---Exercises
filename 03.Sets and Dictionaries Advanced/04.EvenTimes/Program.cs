using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = new Dictionary<int, int>();

            for(int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!result.ContainsKey(input))
                {
                    result.Add(input, 0);
                }

                result[input]++;
            }

            foreach(var item in result)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }
        }
    }
}
