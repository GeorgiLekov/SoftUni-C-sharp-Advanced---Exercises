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

            Stack<int> stack = new Stack<int>(itemsToPush);

            for(int i = 0; i < numberOfPops; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(itemToSearch))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
