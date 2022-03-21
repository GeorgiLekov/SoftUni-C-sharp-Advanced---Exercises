using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for(int i = 0; i < n; i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[n - 1 - i, i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }
    }
}
