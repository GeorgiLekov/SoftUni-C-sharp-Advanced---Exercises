using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Tire
    {
        public int Age { get; set; }

        public float Pressure { get; set; }

        public Tire()
        {

        }

        public Tire(float pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}
