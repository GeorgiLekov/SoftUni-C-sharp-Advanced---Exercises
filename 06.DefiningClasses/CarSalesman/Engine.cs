using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Engine
    {
        public string Model { get; set; }

        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficency { get; set; }

        public Engine()
        {
            Model = "n/a";
            Power = "n/a";
            Displacement = "n/a";
            Efficency = "n/a";
        }
        public Engine(string modelInput, string powerInput):this()
        {
            Model = modelInput;
            Power = powerInput;
        }

        public Engine(string modelInput, string powerInput, string displacementInput, string efficencyInput):this()
        {
            Model = modelInput;
            Power = powerInput;
            Displacement = displacementInput;
            Efficency = efficencyInput;
        }
    }
}
