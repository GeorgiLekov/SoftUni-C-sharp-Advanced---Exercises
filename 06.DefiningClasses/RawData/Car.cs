using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        public string Model { get; set; }

        public Engine engine = new Engine();

        public Cargo cargo = new Cargo();

        public Tire[] tires = new Tire[4];

        public Car(string modelInput,Engine engineInput, Cargo cargoInput,Tire[] tiresInput)//masiv gumi napravo
        {
            Model = modelInput;
            engine = engineInput;
            cargo = cargoInput;
            tires = tiresInput;
        }
    }
}
