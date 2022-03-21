using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationsFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<List<string>> filters = new List<List<string>>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] instruction = command.Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(instruction[0]=="Add filter")
                {
                    List<string> temp = new List<string>();
                    temp.Add(instruction[1]);
                    temp.Add(instruction[2]);
                    filters.Add(temp);
                }
                else if (instruction[0]=="Remove filter")
                {
                    List<string> temp = new List<string>();
                    temp.Add(instruction[1]);
                    temp.Add(instruction[2]);

                    for(int i = 0; i < filters.Count; i++)
                    {
                        if(filters[i][0] == instruction[1] && filters[i][1] == instruction[2])
                        {
                            filters.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            for(int i = 0; i < filters.Count; i++)
            {
                string instruction = filters[i][0];
                string value = filters[i][1];

                names.RemoveAll(GetPredicate(instruction, value));
            }
            Console.WriteLine(string.Join(" ",names));
        }

        private static Predicate<string> GetPredicate(string instruction, string value)
        {
            switch (instruction)
            {
                case "Starts with":
                    return x => x.StartsWith(value);

                case "Ends with":
                    return x => x.EndsWith(value);

                case "Length":
                    return x => x.Length == int.Parse(value);

                case "Contains":
                    return x => x.Contains(value);
            }

            return x => x == "shanadanadhdu";
        }
    }
}
