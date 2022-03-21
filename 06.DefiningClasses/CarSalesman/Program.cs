using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[n];

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Length == 2)
                {
                    engines[i] = new Engine(command[0], command[1]);
                }
                else if (command.Length == 4)
                {
                    engines[i] = new Engine(command[0], command[1], command[2], command[3]);
                }
                else if(command.Length == 3)
                {
                    bool isInt = int.TryParse(command[2], out var number);
                    engines[i] = new Engine(command[0], command[1]);
                    if (isInt)
                    {
                        engines[i].Displacement = command[2];
                    }
                    else
                    {
                        engines[i].Efficency = command[2];
                    }
                }
            }

            n = int.Parse(Console.ReadLine());

            Car[] cars = new Car[n];
            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int indexOfEngine = -1;

                for(int j = 0; j < engines.Length; j++)
                {
                    if (engines[j].Model == command[1])
                    {
                        indexOfEngine = j; 
                        break;
                    }
                }

                if(indexOfEngine == -1)
                {
                    cars[i] = new Car(command[0], new Engine());
                }
                else
                {
                    cars[i] = new Car(command[0], engines[indexOfEngine]);
                }

                if (command.Length == 4)
                {
                    cars[i].Weight = command[2];
                    cars[i].Color = command[3];
                }
                else if (command.Length == 3)
                {
                    bool isInt = int.TryParse(command[2], out int result);

                    if (isInt)
                    {
                        cars[i].Weight = command[2];
                    }
                    else
                    {
                        cars[i].Color = command[2];
                    }
                }
            }
            foreach(var item in cars)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
