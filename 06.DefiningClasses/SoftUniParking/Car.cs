using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string registration)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registration;
        }

        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nHorsePower: {HorsePower}\nRegistrationNumber: {RegistrationNumber}";
        }
    }
}
