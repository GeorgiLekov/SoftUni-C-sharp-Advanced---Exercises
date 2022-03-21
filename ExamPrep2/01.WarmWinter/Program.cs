using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] scarfsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> set = new List<int>();

            Stack<int> hats = new Stack<int>(hatsInput);
            Queue<int> scarfs = new Queue<int>(scarfsInput);

            while (hats.Count>0&&scarfs.Count>0) 
            {
                int tempHat = hats.Peek();
                int tempScarf = scarfs.Peek();

                if (tempHat > tempScarf)
                {
                    set.Add(tempHat + tempScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (tempScarf > tempHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int increment = tempHat + 1;
                    hats.Pop();
                    hats.Push(increment);
                }

            }
            Console.WriteLine($"The most expensive set is: {set.Max()}");
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
