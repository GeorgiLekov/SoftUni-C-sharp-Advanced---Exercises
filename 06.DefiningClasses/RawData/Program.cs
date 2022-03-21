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
                string[] instructions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = instructions[0];

                int engineSpeed = int.Parse(instructions[1]);
                int enginePower = int.Parse(instructions[2]);
                Engine tempEngine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(instructions[3]);
                string cargoType = instructions[4];
                Cargo tempCargo = new Cargo(cargoType, cargoWeight);
                
                Tire[] tempTires = new Tire[4];
                int count = 0;
                for(int j = 0; j < 4; j++)
                {
                    tempTires[j] = new Tire();
                    tempTires[j].Pressure = float.Parse(instructions[count + 5]);
                    tempTires[j].Age = int.Parse(instructions[count + 6]);
                    count += 2;
                }

                cars.Add(new Car(model, tempEngine, tempCargo, tempTires));
            }
            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    foreach(var car in cars)
                    {
                        if (car.cargo.Type == "fragile")
                        {
                            bool hasNeededTypeOfTire = false;
                            foreach(var tyre in car.tires)
                            {
                                if (tyre.Pressure < 1) hasNeededTypeOfTire = true;
                            }
                            if (hasNeededTypeOfTire) Console.WriteLine(car.Model);
                        }
                    }
                    break;

                case "flammable":
                    foreach (var car in cars)
                    {
                        if (car.cargo.Type == "flammable" && car.engine.Power>250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;

            }
        }
    }
}
