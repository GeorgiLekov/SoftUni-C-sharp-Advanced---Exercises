using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodForTheDay = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Count > 0)
            {
                if (foodForTheDay - ordersQueue.Peek() >= 0)
                {
                    foodForTheDay -= ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (ordersQueue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",ordersQueue)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
