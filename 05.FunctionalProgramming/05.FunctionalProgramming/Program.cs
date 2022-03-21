using System;
using System.Linq;

namespace _05.FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string action = Console.ReadLine();

            Func<string, int[], int[]> doSomething = (action, numbers) =>
             {
                 int[] result = new int[numbers.Length];
                 int i = 0;
                 foreach(var number in numbers)
                 {
                     result[i] = number;
                     i++;
                 }

                 switch (action)
                 {
                     case "add":
                         for(int j = 0; j < result.Length; j++)
                         {
                             result[j]++;
                         }
                         break;
                     case "multiply":
                         for (int j = 0; j < result.Length; j++)
                         {
                             result[j] *= 2;
                         }
                         break;

                     case "subtract":
                         for (int j = 0; j < result.Length; j++)
                         {
                             result[j] -= 1;
                         }
                         break;

                     case "print":
                         for (int j = 0; j < result.Length; j++)
                         {
                             Console.Write(result[j] + " ");
                         }
                         Console.WriteLine();
                         break;

                     default:
                         break;
                 }
                 return result;
             };

            while (action != "end")
            {
                numbers = doSomething(action, numbers);

                action = Console.ReadLine();
            }
        }
    }
}
