using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentLiters = bottles.Pop();

                int currentCapacity = cups.Dequeue();

                if (currentLiters - currentCapacity > 0)
                {
                    wastedWater += currentLiters - currentCapacity;
                    continue;
                }
                else
                {
                    currentCapacity -= currentLiters;
                    while (currentCapacity > 0)
                    {
                        if (bottles.Count == 0) break;

                        currentLiters = bottles.Pop();
                        currentCapacity -= currentLiters;

                        if (currentCapacity < 0)
                        {
                            wastedWater += Math.Abs(currentCapacity);
                        }
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
