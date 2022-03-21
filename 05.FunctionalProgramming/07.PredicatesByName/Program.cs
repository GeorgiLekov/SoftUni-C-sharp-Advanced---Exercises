using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicatesByName
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isCertainLenght = (name, lenght) => name.Length <= lenght;

            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            result = names.Where(name => isCertainLenght(name,n)).ToList();

            Console.WriteLine(string.Join("\n",result));
        }
    }
}
