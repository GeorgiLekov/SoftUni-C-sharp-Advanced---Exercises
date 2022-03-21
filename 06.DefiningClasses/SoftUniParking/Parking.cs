using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        public List<Car> cars;
        private int capacity;

        public int Capacity { get { return capacity; } }

        public int Count { get { return cars.Count; } }
        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car input)
        {
            foreach(var car in cars)
            {
                if (car.RegistrationNumber == input.RegistrationNumber) return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(input);

            return $"Successfully added new car {input.Make} {input.RegistrationNumber}";
        }

        public string RemoveCar(string input)
        {
            for(int i = 0; i < cars.Count; i++)
            {
                if (cars[i].RegistrationNumber==input)
                {
                    cars.RemoveAt(i);
                    return $"Successfully removed {input}";
                }
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string input)
        {
            foreach(var car in cars)
            {
                if (car.RegistrationNumber == input) return car;
            }

            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for(int i = 0; i < RegistrationNumbers.Count; i++)
            {
                for(int j = 0; j < cars.Count; j++)
                {
                    if (RegistrationNumbers[i] == cars[j].RegistrationNumber)
                    {
                        cars.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
    }
}
