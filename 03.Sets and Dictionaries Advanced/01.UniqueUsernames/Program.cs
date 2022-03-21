﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for(int i=0;i<n; i++)
            {
                string input = Console.ReadLine();
                uniqueNames.Add(input);
            }
            foreach(var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
