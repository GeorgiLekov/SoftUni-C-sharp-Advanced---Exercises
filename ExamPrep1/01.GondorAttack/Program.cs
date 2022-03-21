using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.GondorAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int numWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToList();

            int count = 0;
            for (int i = 0; i < numWaves; i++)
            {
                List<int> wave = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                wave.Reverse();

                count++;

                if (count == 3)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                    count = 0;
                }

                for (int j = 0; j < wave.Count; j++)
                {
                    while (wave[j] > 0 || plates.Count > 0)
                    {
                        if (plates.Count == 0)
                        {
                            Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                            Console.WriteLine("Orks left: " + string.Join(", ", wave));
                            return;
                        }
                        if (wave[j] > plates[0])
                        {
                            wave[j] -= plates[0];
                            plates.RemoveAt(0);
                        }
                        else if (wave[j] == plates[0])
                        {
                            plates.RemoveAt(0);
                            wave.RemoveAt(j);
                            j--;
                            break;
                        }
                        else
                        {
                            plates[0] -= wave[j];
                            wave.RemoveAt(j);
                            j--;
                            break;
                        }
                    }
                }
            }

            /*
            List<List<int>> orkWaves = new List<List<int>>();

            for(int i = 0; i < numWaves; i++)
            {
                List<int> wave = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                orkWaves.Add(wave);
            }

            int count = 0;
            for(int i = 0; i < orkWaves.Count; i++)
            {
                count++;

                if (count == 3)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                    count = 0;
                }

                for(int j = 0; j < orkWaves[i].Count; j++)
                {
                    int orkWarrior = orkWaves[i][j];

                    while (orkWarrior > 0 || plates.Count > 0)
                    {
                        if (plates.Count == 0)
                        {
                            Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                            List<List<int>> temp = new List<List<int>>();

                            foreach(var wave in orkWaves)
                            {
                                temp.Add(wave.Where(x => x != 0).ToList());
                            }

                            orkWaves = temp;

                            Console.WriteLine("Orks left: " + string.Join(", ", orkWaves));
                            return;
                        }
                        if (orkWarrior > plates[0])
                        {
                            orkWarrior -= plates[0];
                            plates.RemoveAt(0);
                        }
                        else if (orkWarrior == plates[0])
                        {
                            plates.RemoveAt(0);
                            orkWaves[i][j] = 0;
                            break;
                        }
                        else
                        {
                            plates[0] -= orkWarrior;
                            orkWaves[i][j] = 0;
                            break;
                        }
                    }
                }
            }
            */
            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine("Plates left: " + string.Join(", ",plates));
        }
    }
}
