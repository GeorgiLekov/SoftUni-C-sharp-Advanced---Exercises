using System;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int[], bool> isItDivisible = (number, divisors) =>
              {
                  foreach(var divisor in divisors)
                  {
                      if (number % divisor != 0) return false;
                  }
                  return true;
              };

            int range = int.Parse(Console.ReadLine());

            int[] allNumbersInRange = new int[range];

            for(int i = 1; i <= range; i++)
            {
                
                allNumbersInRange[i-1] = i;
            }

            int[] divisorsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] result = allNumbersInRange.Where(number => isItDivisible(number, divisorsInput)).ToArray();

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
