using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int amountOFItemsToPush = command[0];
            int numberOfPops = command[1];
            int itemToSearch = command[2];

            int[] itemsToPush = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue <int>(itemsToPush);

            for (int i = 0; i < numberOfPops; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(itemToSearch))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
