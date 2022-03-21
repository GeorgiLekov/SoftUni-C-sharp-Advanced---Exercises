using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int[], int, List<int>> reverseAndSort = (array, divisor) =>
              {
                  List<int> result = new List<int>();
                  
                  for(int i = array.Length - 1; i >= 0; i--)
                  {
                      if (array[i] % divisor != 0)
                      {
                          result.Add(array[i]);
                      }
                  }

                  return result;
              };

            numbers = reverseAndSort(numbers, n).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
