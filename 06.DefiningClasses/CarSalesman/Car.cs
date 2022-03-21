using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public Car()
        {
            Model = "n/a";
            Weight = "n/a";
            Color = "n/a";
        }
        public Car(string modelInput, Engine engineInput):this()
        {
            Model = modelInput;
            Engine = engineInput;
        }
        public Car(string modelInput, Engine engineInput, string weightInput): this()
        {
            Model = modelInput;
            Engine = engineInput;
            Weight = weightInput;
        }
        public Car(string modelInput, Engine engineInput, string weightInput, string colorInput): this()
        {
            Model = modelInput;
            Engine = engineInput;
            Weight = weightInput;
        }

        public override string ToString()
        {
            return $"{Model}:\n {Engine.Model}:\n\tPower: {Engine.Power}\n\tDisplacement: {Engine.Displacement}\n\tEfficiency: {Engine.Efficency}\n Weight: {Weight}\n Color: {Color}";
        }
    }
    /*"{CarModel}:
  {EngineModel}:
    Power: {EnginePower}
    Displacement: {EngineDisplacement}
    Efficiency: {EngineEfficiency}
  Weight: {CarWeight}
  Color: {CarColor}"

*/
}
