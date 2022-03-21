using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car temp = new Car();

                temp.Model = input[0];
                temp.FuelAmount = double.Parse(input[1]);
                temp.FuelConsumptionPerKilometer = double.Parse(input[2]);

                cars.Add(temp);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] instructions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (instructions[0] == "Drive")
                {
                    string model = instructions[1];
                    for(int i = 0; i < cars.Count; i++)
                    {
                        if (cars[i].Model == model)
                        {
                            cars[i].DriveIfYouCan(double.Parse(instructions[2]));
                        }
                    }
                }
                command = Console.ReadLine();
            }

            foreach(var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TravelledDistance}");
            }
        }
    }
}
