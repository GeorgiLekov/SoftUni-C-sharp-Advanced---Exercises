using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Action<string[]> printAction = x => Console.WriteLine(string.Join(Environment.NewLine,x));

            string[] input = Console.ReadLine().Split().ToArray();

            printAction(input);*/

            bool intTryParse = int.TryParse("12", out int result);

            Console.WriteLine(intTryParse);
            Console.WriteLine(result);
        }
    }
}
