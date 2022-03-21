using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> customerMin = numbers =>
             {
                 int min = int.MaxValue;
                 foreach(var number in numbers)
                 {
                     if (min > number) min = number;
                 }
                 return min;
             };

            Console.WriteLine(customerMin(numbers));
        }
    }
}
