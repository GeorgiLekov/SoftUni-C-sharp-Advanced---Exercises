using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] column = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = column[j];
                }
            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] instruction = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (instruction[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    List<int> coordinates = new List<int>();
                    for(int i = 1; i < instruction.Length; i++)
                    {
                        bool isDigit = true;
                        for(int k = 0; k < instruction[i].Length; k++) 
                        {
                            if (!char.IsDigit(instruction[i][k])) isDigit = false;
                        }
                        if (!isDigit) 
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        int number = int.Parse(instruction[i]);
                        bool validCoordinate = false;

                        if (i % 2 == 0)
                        {
                            if (number >= 0 && number < columns)
                            {
                                validCoordinate = true;
                            }
                        }
                        else
                        {
                            if (number >= 0 && number < rows)
                            {
                                validCoordinate = true;
                            }
                        }
                        if (validCoordinate)
                        {
                            coordinates.Add(number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                    }
                    if (coordinates.Count == 4)
                    {
                        string temp = matrix[coordinates[0], coordinates[1]];
                        matrix[coordinates[0], coordinates[1]] = matrix[coordinates[2], coordinates[3]];
                        matrix[coordinates[2], coordinates[3]] = temp;
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
