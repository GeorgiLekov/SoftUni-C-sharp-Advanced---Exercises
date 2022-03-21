using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<List<char>> pond = new List<List<char>>();

            for(int i = 0; i < n; i++)
            {
                pond.Add(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList());
            }

            string command = Console.ReadLine();
            List<char> branches = new List<char>();
            int allBranches = FindAllBranches(pond, n);
            int collectedBranches = 0;

            while (command != "end" && collectedBranches < allBranches)
            {
                int[] currentPosition = new int[2];
                currentPosition = FindTheBeaver(pond, n);

                if (command == "up")
                {
                    int newRow = currentPosition[0] - 1;
                    int newCol = currentPosition[1];
                    int oldRow = currentPosition[0];
                    int oldCol = currentPosition[1];

                    if (!IsInPond(newRow, newCol, pond))
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches,ref collectedBranches);
                    }
                    else if (pond[newRow][newCol] == 'F')
                    {
                        pond[newRow][newCol] = '-';

                        if (newRow == 0)
                        {
                            Action(pond, n - 1, newCol, oldRow, oldCol, branches, ref collectedBranches);
                        }
                        else
                        {
                            Action(pond, 0, newCol, oldRow, oldCol, branches, ref collectedBranches);
                        }
                    }
                    else
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                }
                else if (command == "down")
                {
                    int newRow = currentPosition[0] + 1;
                    int newCol = currentPosition[1];
                    int oldRow = currentPosition[0];
                    int oldCol = currentPosition[1];
                    if (!IsInPond(newRow, newCol, pond))
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                    else if (pond[newRow][newCol] == 'F')
                    {
                        pond[newRow][newCol] = '-';

                        if (newRow == n - 1)
                        {
                            Action(pond, 0, newCol, oldRow, oldCol, branches, ref collectedBranches);
                        }
                        else
                        {
                            Action(pond, n-1, newCol, oldRow, oldCol, branches, ref collectedBranches);
                        }
                    }
                    else
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                }
                else if (command == "left")
                {
                    int newRow = currentPosition[0];
                    int newCol = currentPosition[1] - 1;
                    int oldRow = currentPosition[0];
                    int oldCol = currentPosition[1];
                    if (!IsInPond(newRow, newCol, pond))
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                    else if (pond[newRow][newCol] == 'F')
                    {
                        pond[newRow][newCol] = '-';

                        if (newCol == 0)
                        {
                            Action(pond, newRow, n-1, oldRow, oldCol, branches, ref collectedBranches);
                        }
                        else
                        {
                            Action(pond, newRow, 0, oldRow, oldCol, branches, ref collectedBranches);
                        }
                    }
                    else
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                }
                else if (command == "right")
                {
                    int newRow = currentPosition[0];
                    int newCol = currentPosition[1] + 1;
                    int oldRow = currentPosition[0];
                    int oldCol = currentPosition[1];
                    if (!IsInPond(newRow,newCol,pond))
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                    else if (pond[newRow][newCol] == 'F')
                    {
                        pond[newRow][newCol] = '-';

                        if (newCol == n-1)
                        {
                            Action(pond, newRow, 0, oldRow, oldCol, branches, ref collectedBranches);
                        }
                        else
                        {
                            Action(pond, newRow, n-1, oldRow, oldCol, branches, ref collectedBranches);
                        }
                    }
                    else
                    {
                        Action(pond, newRow, newCol, oldRow, oldCol, branches, ref collectedBranches);
                    }
                }
                command = Console.ReadLine();
            }

            if (collectedBranches == allBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: " + string.Join(", ",branches) + ".");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {allBranches - collectedBranches} branches left.");
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(pond[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int FindAllBranches(List<List<char>> pond, int size)
        {
            int temp = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (char.IsLetter(pond[i][j]) && pond[i][j]!='B' && pond[i][j] != 'F')
                    {
                        temp++;
                    }
                }
            }

            return temp;
        }

        private static void Action(List<List<char>> pond, int newRow, int newCol,int oldRow, int oldCow, List<char> branches, ref int collectedBranches)
        {
            if (!IsInPond(newRow, newCol,pond))
            {
                if (branches.Count > 0)
                {
                    branches.RemoveAt(branches.Count - 1);
                }
            }
            else if (pond[newRow][newCol] == '-')
            {
                pond[newRow][newCol] = 'B';
                pond[oldRow][oldCow] = '-';
            }
            else if (char.IsLetter(pond[newRow][newCol]) && pond[newRow][newCol]!='F'&& pond[newRow][newCol] != 'B')
            {
                branches.Add(pond[newRow][newCol]);
                collectedBranches++;

                pond[newRow][newCol] = 'B';
                pond[oldRow][oldCow] = '-';
            }
            
        }

        private static bool IsInPond(int newRow, int newCol, List<List<char>> pond)
        {
            if (newRow >= 0 && newRow < pond[0].Count)
            {
                if (newCol >= 0 && newCol < pond[0].Count)
                {
                    return true;
                }
            }
            return false;
        }

        private static int[] FindTheBeaver(List<List<char>> pond, int size)
        {
            int[] temp = new int[2];

            for (int i=0;i< size; i++)
            {
                for(int j=0; j < size; j++)
                {
                    if (pond[i][j] == 'B')
                    {
                        temp[0] = i;
                        temp[1] = j;
                        return temp;
                    }
                }
            }

            return temp;
        }
    }
}
