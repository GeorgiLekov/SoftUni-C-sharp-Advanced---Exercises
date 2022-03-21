using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Cargo
    {
        public string Type { get; set; }

        public int Weight { get; set; }

        public Cargo()
        {

        }

        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
