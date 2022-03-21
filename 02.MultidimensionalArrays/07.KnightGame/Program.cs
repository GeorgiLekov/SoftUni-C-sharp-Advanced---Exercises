using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = FillMatrix(n);
            int knightsOnTheField = FindKnights(field,n);
            int knightsRemoved = 0;

            for(int i = 0; i < knightsOnTheField; i++)
            {
                Dictionary<int[],int> killPotential = new Dictionary<int[], int>();
                for(int k = 0; k < n; k++)
                {
                    for(int m = 0; m < n; m++)
                    {
                        if (field[k, m] == 'K')
                        {
                            int[] coordinates = { k, m };
                            if (!killPotential.ContainsKey(coordinates))
                            {
                                killPotential.Add(coordinates, 0);
                            }
                            killPotential[coordinates] = AttackPower(k, m, field, n);
                        }
                    }
                }
                int[] coordinatesFinal = FindBiggestPotential(killPotential);
                if(killPotential[coordinatesFinal] == 0)
                {
                    break;
                }
                else
                {
                    field[coordinatesFinal[0], coordinatesFinal[1]] = '0';
                    knightsRemoved++;
                }
            }
            Console.WriteLine(knightsRemoved);
        }

        private static int[] FindBiggestPotential(Dictionary<int[], int> killPotential)
        {
            int[] coordinatesOfBiggest = new int[2];
            int maxValue = int.MinValue;

            foreach(var knight in killPotential)
            {
                if (knight.Value > maxValue)
                {
                    maxValue = knight.Value;
                    coordinatesOfBiggest = knight.Key;
                }
            }

            return coordinatesOfBiggest;
        }

        private static int AttackPower(int k, int m, char[,] field, int n)
        {
            int count = 0;
            // {k-2,m-1}{k-2,m+1} {k-1,m+2}{k+1,m+2} {k+2,m+1}{k+2,m-1} {k+1,m-2}{k-1,m-2}
            if (ValidateCoordinates(k - 2, m - 1, n))
            {
                if (field[k - 2, m - 1] == 'K')
                {
                    count++;
                }
            }
            if (ValidateCoordinates(k - 2, m + 1, n))
            {
                if (field[k - 2, m + 1] == 'K')
                {
                    count++;
                }
            }

            if (ValidateCoordinates(k - 1, m + 2, n))
            {
                if (field[k - 1, m + 2] == 'K')
                {
                    count++;
                }
            }
            if (ValidateCoordinates(k + 1, m + 2, n))
            {
                if (field[k + 1, m + 2] == 'K')
                {
                    count++;
                }
            }

            if (ValidateCoordinates(k + 2, m + 1, n))
            {
                if (field[k + 2, m + 1] == 'K')
                {
                    count++;
                }
            }
            if (ValidateCoordinates(k + 2, m - 1, n))
            {
                if (field[k + 2, m - 1] == 'K')
                {
                    count++;
                }
            }

            if (ValidateCoordinates(k + 1, m - 2, n))
            {
                if (field[k + 1, m - 2] == 'K')
                {
                    count++;
                }
            }
            if (ValidateCoordinates(k - 1, m - 2, n))
            {
                if (field[k - 1, m - 2] == 'K')
                {
                    count++;
                }
            }

            return count;
        }

        private static bool ValidateCoordinates(int v1, int v2, int size)
        {
            if (v1 >= 0 && v1 < size && v2 >= 0 && v2 < size)
            {
                return true;
            }
            return false;
        }

        private static int FindKnights(char[,] field, int size)
        {
            int knights = 0;

            for(int i = 0; i < size; i++)
            {
                for(int j =0; j < size; j++)
                {
                    if (field[i, j] == 'K')
                    {
                        knights++;
                    }
                }
            }

            return knights;
        }

        private static char[,] FillMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for(int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            return matrix;
        }
    }
}
