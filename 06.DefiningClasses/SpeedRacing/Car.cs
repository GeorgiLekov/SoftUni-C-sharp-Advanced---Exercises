using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void DriveIfYouCan(double distance)
        {
            if (FuelConsumptionPerKilometer * distance <= FuelAmount)
            {
                double fuelPrice = FuelConsumptionPerKilometer * distance;
                FuelAmount -= fuelPrice;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
