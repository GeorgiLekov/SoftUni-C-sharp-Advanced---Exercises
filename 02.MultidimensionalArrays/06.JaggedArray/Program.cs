using System;
using System.Linq;

namespace _06.JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];
            //fill the array
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jaggedArray[i] = new double[line.Length];
                for(int j = 0; j < line.Length; j++)
                {
                    jaggedArray[i][j] = line[j];
                }
            }

            jaggedArray = AnalizeTheArray(jaggedArray, n);

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] instruction = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                bool isValid = ValidateInstruction(instruction, jaggedArray);

                if (isValid)
                {
                    int lines = int.Parse(instruction[1]);
                    int col = int.Parse(instruction[2]);
                    double value = int.Parse(instruction[3]);
                    switch (instruction[0])
                    {
                        case "Add":
                            jaggedArray[lines][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[lines][col] -= value;
                            break;
                    }
                }
                command = Console.ReadLine();
            }
            printTheArray(jaggedArray, n);
        }

        private static bool ValidateInstruction(string[] instruction, double[][] array)
        {
            if (!(instruction.Length == 4))
            {
                return false;
            }
            for(int i = 1; i < instruction.Length; i++)
            {
                for(int k = 0; k < instruction[i].Length; k++)
                {
                    if ((!char.IsDigit(instruction[i][k])) && instruction[i][k] != '-')
                    {
                        return false;
                    }
                }
            }

            int line = int.Parse(instruction[1]);
            int col = int.Parse(instruction[2]);

            if (!(line >= 0 && line<array.GetLength(0)) || !(col >= 0 && col < array[line].Length))
            {
                return false;
            }

            return true;
        }

        private static void printTheArray(double[][] jaggedArray,int n)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static double[][] AnalizeTheArray(double[][] jaggedArray, int n)
        {
            double[][] theNewArray = new double[n][];

            //copy the original array
            for(int i = 0; i < n; i++)
            {
                int currentLenght = jaggedArray[i].Length;
                theNewArray[i] = new double[currentLenght];

                for(int j = 0; j < currentLenght; j++)
                {
                    theNewArray[i][j] = jaggedArray[i][j];
                }
            }

            for(int i = 0; i < n - 1; i++)
            {
                bool areSameLenght = theNewArray[i].Length == theNewArray[i + 1].Length;
                if (areSameLenght)
                {
                    for(int j = 0; j < theNewArray[i].Length; j++)
                    {
                        theNewArray[i][j] *= 2;
                        theNewArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < theNewArray[i].Length; j++)
                    {
                        theNewArray[i][j] /= 2;
                    }
                    for (int j = 0; j < theNewArray[i+1].Length; j++)
                    {
                        theNewArray[i+1][j] /= 2;
                    }
                }
            }

            return theNewArray;
        }
    }
}
