using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rowDimension = dimensions[0];
            int colDimension = dimensions[1];

            char[,] matrix = new char[dimensions[0], dimensions[1]];
            for(int row = 0; row < rowDimension; row++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for(int col = 0; col < colDimension; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int squaresFound = 0;

            for(int row = 0; row < rowDimension - 1; row++)
            {
                for(int col = 0; col < colDimension - 1; col++)
                {
                    char occurance = matrix[row, col];
                    bool isIt = 
                        matrix[row, col + 1] == occurance && 
                        matrix[row + 1, col] == occurance && 
                        matrix[row + 1, col + 1] == occurance;

                    if (isIt)
                    {
                        squaresFound++;
                    }
                }
            }
            Console.WriteLine(squaresFound);
        }
    }
}
