using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string action = Console.ReadLine();

            while(action != "Party!")
            {
                string[] commands = action.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string method = commands[0];
                string position = commands[1];
                string search = commands[2];

                switch (method) 
                {
                    case "Double":
                        List<string> doubleNames = names.FindAll(GetPredicate(position, search));
                        int count = 0;
                        while (count < doubleNames.Count)
                        {
                            for(int i = 0; i < names.Count; i++)
                            {
                                if (names[i] == doubleNames[count])
                                {
                                    names.Insert(i, names[i]);
                                    break;
                                }
                            }
                            count++;
                        }
                        break;

                    case "Remove":
                        names.RemoveAll(GetPredicate(position, search));
                        break;
                }

                action = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ",names)+" are going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string position, string search)
        {
            if (position == "StartsWith")
            {
                return x => x.StartsWith(search);
            }
            else if(position == "EndsWith")
            {
                return x => x.EndsWith(search);
            }
            else if(position == "Length")
            {
                return x => x.Length == int.Parse(search);
            }

            return x => x.EndsWith("shabadadbabaddu");
        }
    }
}
