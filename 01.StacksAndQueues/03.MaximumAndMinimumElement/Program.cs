using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            while (n > 0)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (command[0]) 
                {
                    case 1:
                        stack.Push(command[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;

                }

                n--;
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
