using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> sirs = knightlyNames =>
           {
               foreach (var name in knightlyNames)
               {
                   Console.WriteLine($"Sir {name}");
               }
           };

            string[] names = Console.ReadLine().Split();

            sirs(names);
        }
    }
}
