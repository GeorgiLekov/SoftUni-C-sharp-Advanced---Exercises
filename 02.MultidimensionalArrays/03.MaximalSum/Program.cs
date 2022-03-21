using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];
            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] column = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < column.Length; j++)
                {
                    matrix[i, j] = column[j];
                }
            }

            int maxSum = int.MinValue;
            int currentSum = 0;

            int winnerRow = 0;
            int winnerCol = 0;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < columns - 2; j++)
                {
                    currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j] +
                        matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > maxSum)
                    {
                        winnerRow = i;
                        winnerCol = j;
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = winnerRow; i < winnerRow + 3; i++)
            {
                for (int j = winnerCol; j < winnerCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();

            }


        }
    }
}
