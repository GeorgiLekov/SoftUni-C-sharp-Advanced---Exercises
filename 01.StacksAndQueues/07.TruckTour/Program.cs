using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] stations = new int[n,2];
            
            for(int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                stations[i, 0] = input[0];
                stations[i, 1] = input[1];
            }

            bool fullCircle = true;

            for (int i = 0; i < n; i++)
            {
                int count = i;
                fullCircle = true;
                int petrol = 0;
                for(int j = 0; j < n; j++)
                {
                    petrol += stations[count, 0];
                    petrol -= stations[count, 1];

                    if (petrol < 0)
                    {
                        fullCircle = false;
                    }
                    count++;
                    if (count == n)
                    {
                        count = 0;
                    }
                }
                if (fullCircle)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
