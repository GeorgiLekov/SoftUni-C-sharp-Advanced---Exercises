using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    int currentGreen = greenLight;
                    while (currentGreen > 0)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        string currentCar = cars.Dequeue();
                        int currentCarLenght = currentCar.Length;

                        if (currentCarLenght <= currentGreen)
                        {
                            currentGreen -= currentCarLenght;
                            carsPassed++;
                        }
                        else if (currentCarLenght <= currentGreen + freeWindow)
                        {
                            currentGreen = 0;
                            carsPassed++;
                        }
                        else
                        {
                            int crashIndex = currentGreen + freeWindow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[crashIndex]}.");
                            return;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
