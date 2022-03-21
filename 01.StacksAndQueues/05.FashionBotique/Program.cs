using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBotique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int racks = 1;

            Stack<int> clothes = new Stack<int>(inputClothes);

            int capacity = int.Parse(Console.ReadLine());

            while (clothes.Count > 0)
            {
                int currentCapacity = capacity;
                while (currentCapacity >= 0 && clothes.Count > 0)
                {
                    if (currentCapacity - clothes.Peek() < 0)
                    {
                        racks++; 
                        break;
                    }
                    currentCapacity -= clothes.Pop();
                }
            }
            Console.WriteLine(racks);
        }
    }
}
