using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> groupOfPeople = new List<Person>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person temp = new Person(input[0],int.Parse(input[1]));

                groupOfPeople.Add(temp);
            }

            groupOfPeople = groupOfPeople.Where(individual => individual.Age > 30).OrderBy(individual => individual.Name).ToList();

            foreach(var item in groupOfPeople)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
