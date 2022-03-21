using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenght = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            setOne = FillTheSet(lenght[0]);
            setTwo = FillTheSet(lenght[1]);

            List<int> result = new List<int>();
            foreach(int item in setOne)
            {
                if (setTwo.Contains(item))
                {
                    result.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }

        private static HashSet<int> FillTheSet(int lenght)
        {
            HashSet<int> set = new HashSet<int>();
            for(int i = 0; i < lenght; i++)
            {
                int input = int.Parse(Console.ReadLine());
                set.Add(input);
            }

            return set;
        }
    }
}
