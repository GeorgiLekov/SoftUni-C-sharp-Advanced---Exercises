using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string evenOrOdd = Console.ReadLine();

            List<int> numbersInRange = new List<int>();

            for(int i = rangeInput[0]; i <= rangeInput[1]; i++)
            {
                numbersInRange.Add(i);
            }

            Predicate<int> findEven = number => number % 2 == 0;
            Predicate<int> findOdd = number => number % 2 != 0;

            if (evenOrOdd == "even")
            {
                numbersInRange = numbersInRange.FindAll(findEven);
            }
            else if(evenOrOdd == "odd")
            {
                numbersInRange = numbersInRange.FindAll(findOdd);
            }

            Console.WriteLine(string.Join(" ", numbersInRange));
        }
    }
}
