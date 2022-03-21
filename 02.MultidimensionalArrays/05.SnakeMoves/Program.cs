using System;
using System.Linq;

namespace _05.SnakeMoves
{
    //https://judge.softuni.org/Contests/Compete/Index/1455#5
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            int rows = dimensions[0];
            int columns = dimensions[1];
            int count = 0;

            char[,] isle = new char[rows, columns];

            bool weGoRight = true;

            for(int i = 0; i < rows; i++)
            {
                if (weGoRight)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        isle[i, j] = snake[count];
                        count++;
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                    weGoRight = false;
                }
                else
                {
                    for (int j = columns - 1; j >= 0; j--)
                    {
                        isle[i, j] = snake[count];
                        count++;
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                    weGoRight = true;
                }
            }

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write(isle[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
